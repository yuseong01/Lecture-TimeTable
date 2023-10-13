using LTT.Controller;
using LTT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Utility;
using LTT.Model;
using LTT.Controller.RegistrationSystem;

namespace LTT.Main
{
    class MainCourseSelection 
    {
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private Login login;        
        private MenuView menuView;             //메인메뉴 UI
        private LectureStudentData lectureStudentData;      //로그인한 학생에 해당하는 학생의 강의와 학생정보를 담아주는 리스트
        private LecturePrintForm subjectPrintForm;  
        private LectureSearch lectureSearch;
        private LectureLoader lectureLoader;
        private CourseSelection interestLecture;
        private Cursor cursor;
        private RegistrationMenu registrationCourseMenu;
        private ScheduleExcelUploader scheduleExcelUploader;

        public MainCourseSelection() 
        {
            inputKey = new InputKey();
            exceptionHandler = new ExceptionHandler();
            menuView = new MenuView();
            lectureStudentData = new LectureStudentData();  //학생-강의데이터 모아둔 리스트
            subjectPrintForm = new LecturePrintForm();      //불러온 강의리스트 출력해주는 view
            lectureLoader = new LectureLoader();        //엑셀 강의 정보 다 리스트에 넣어줌
            cursor = new Cursor(inputKey);
            lectureStudentData.StudentList.Add(new Student(19011534, "tkfkd1004",0,0));
            login = new Login(inputKey,exceptionHandler, menuView, lectureStudentData, cursor);
            lectureSearch = new LectureSearch(subjectPrintForm, inputKey, lectureStudentData, cursor);
            interestLecture = new CourseSelection(menuView,inputKey,exceptionHandler,lectureSearch,lectureStudentData, subjectPrintForm);
            registrationCourseMenu = new RegistrationMenu(menuView, inputKey, exceptionHandler, lectureSearch, lectureStudentData, subjectPrintForm);
            scheduleExcelUploader = new ScheduleExcelUploader(lectureStudentData);
        }

        public void SelectCourse()
        {
            lectureLoader.LoadExcel(lectureStudentData);    //엑셀 데이터를 로드해 강의리스트에 넣어줌

            int studentIndex = 0;    //로그인 하고 해당하는 학생의 인덱스를 받아줌

            string inputMenuString;
            int menuNumber;
            bool usingLTT=true;

            while (studentIndex != Constant.Constant.ESC)
            {
                studentIndex = login.GetLogin();
                if (studentIndex == Constant.Constant.ESC)
                {
                    return;
                }
                //메소드로 빼기
                while (usingLTT)
                {
                    Console.Clear();

                    menuView.PrintMenu();   //메인메뉴 4개 출력       

                    inputMenuString = inputKey.EnterKey(false);
                    
                    if (inputMenuString == Constant.Constant.ESC_STRING)
                    {
                        break;
                    }
                    if (!exceptionHandler.IsMatch(inputMenuString, Constant.Constant.MENU))   //4번까지 입력 가능하도록 예외처리
                    {
                        continue;
                    }
                    menuNumber = int.Parse(inputMenuString);


                    switch (menuNumber) //메뉴 번호에 따라 기능 선택
                    {
                        case 1:
                            lectureSearch.FindCourse();  //강의 시간표 조회
                            Console.ReadKey(true);
                            break;
                        case 2:
                            interestLecture.InterestedLectureCourseSelection(studentIndex);
                            break;
                        case 3:
                            registrationCourseMenu.RegisterLectureCourseSelection(studentIndex);
                            break;
                        case 4:
                            scheduleExcelUploader.UploadSchedule(studentIndex, lectureStudentData.TimeTable);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}