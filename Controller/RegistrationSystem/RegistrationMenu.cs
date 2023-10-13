using LTT.Controller.InterestLecture;
using LTT.Model;
using LTT.View;
using LTT.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller.RegistrationSystem
{
    class RegistrationMenu
    {
        private MenuView menuView;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private SearchAdd searchAdd;
        private LectureSearch lectureSearch;
        private LectureStudentData data;
        private LecturePrintForm lecturePrintForm;
        private Delete deleteInterestedLecture;
        private CourseRegistration registrationLecture;
        private RegistrationLecture searchRegisteration;
        private DeleteRegistrationLecture deleteRegistrationLecture;
        private ScheduleExcelUploader scheduleExcelUploader;

        public RegistrationMenu(MenuView menuView, InputKey inputKey, ExceptionHandler exceptionHandler, LectureSearch lectureSearch, LectureStudentData data, LecturePrintForm lecturePrintForm)
        {
            this.menuView = menuView;
            this.inputKey = inputKey;
            this.exceptionHandler = exceptionHandler;
            this.lectureSearch = lectureSearch;
            this.data = data;
            this.lecturePrintForm = lecturePrintForm;
            scheduleExcelUploader = new ScheduleExcelUploader(data);
            searchAdd = new SearchAdd(lectureSearch, inputKey, data, exceptionHandler);
            deleteInterestedLecture = new Delete(lecturePrintForm, data, inputKey, exceptionHandler);
            searchRegisteration = new RegistrationLecture(lectureSearch, inputKey, data, exceptionHandler,lecturePrintForm);
            registrationLecture = new CourseRegistration(menuView, inputKey,exceptionHandler,searchRegisteration);
            deleteRegistrationLecture = new DeleteRegistrationLecture(lecturePrintForm, data, inputKey,exceptionHandler);
        }
        public void RegisterLectureCourseSelection(int studentId)
        {
            string inputMenuString;
            int menuNumber;

            while (true)
            {
                Console.Clear();

                menuView.PrintRegistrationLectureMenu();     

                inputMenuString = inputKey.EnterKey(false);
                if (inputMenuString == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                if (!exceptionHandler.IsMatch(inputMenuString, Constant.Constant.MENU))   //4번까지 입력 가능하도록 예외처리
                {
                    continue;
                }
                menuNumber = int.Parse(inputMenuString);


                switch (menuNumber) //메뉴 번호에 따라 기능 선택
                {
                    case 1:
                        registrationLecture.RegisterCourse(studentId);
                        Console.ReadKey(true);
                        break;
                    case 2:
                        lecturePrintForm.ShowRegistrationLecture(studentId, data);
                        Console.WriteLine("뒤로가기 : ESC");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        break;
                    case 4:
                        deleteRegistrationLecture.DeleteLecture(studentId);
                        Console.ReadKey(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
