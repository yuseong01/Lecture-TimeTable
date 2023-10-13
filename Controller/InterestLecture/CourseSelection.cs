using LTT.Controller.InterestLecture;
using LTT.Model;
using LTT.Utility;
using LTT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller
{
    class CourseSelection
    {
        private MenuView menuView;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private SearchAdd searchAdd;
        private LectureSearch lectureSearch;
        private LectureStudentData data;
        private LecturePrintForm lecturePrintForm;
        private Delete deleteInterestedLecture;

        public CourseSelection(MenuView menuView, InputKey inputKey, ExceptionHandler exceptionHandler,LectureSearch lectureSearch, LectureStudentData data, LecturePrintForm lecturePrintForm) 
        {
            this.menuView = menuView;
            this.inputKey = inputKey;
            this.exceptionHandler = exceptionHandler;
            this.lectureSearch = lectureSearch;
            this.data = data;
            this.lecturePrintForm = lecturePrintForm;
            searchAdd = new SearchAdd(lectureSearch, inputKey, data, exceptionHandler);
            deleteInterestedLecture = new Delete(lecturePrintForm, data,inputKey, exceptionHandler);
        }
        public void InterestedLectureCourseSelection(int studentId)
        {
            string inputMenuString;
            int menuNumber;


            while (true)
            {
                Console.Clear();

                menuView.PrintInterestedLectureMenu();   //관심과목담기 메뉴 4개 출력       

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
                        searchAdd.AddInterestedLecture(studentId);  //강의 시간표 조회
                        break;
                    case 2:
                        lecturePrintForm.ShowInterestedLecture(studentId,data);
                        Console.WriteLine("뒤로가기 : ESC");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        break;
                    case 4:
                        deleteInterestedLecture.DeleteInterestedLecture(studentId);
                        Console.ReadKey(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
