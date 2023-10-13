using LTT.Controller.InterestLecture;
using LTT.Model;
using LTT.Utility;
using LTT.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller.RegistrationSystem
{
    class CourseRegistration
    {
        private MenuView menuView;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private RegistrationLecture searchRegisteration;
        public CourseRegistration(MenuView menuView,InputKey inputKey,ExceptionHandler exceptionHandler, RegistrationLecture searchRegisteration)
        {
            this.menuView = menuView;
            this.inputKey = inputKey;
            this.exceptionHandler = exceptionHandler; 
            this.searchRegisteration = searchRegisteration;
        }
        public void RegisterCourse(int studentIndex)
        {
            string inputMenuString;
            int menuNumber;
            string lectureRegisterCourse;

            while (true)
            {
                Console.Clear();

                menuView.PrintRegistrationCourseMenu();          

                inputMenuString = inputKey.EnterKey(false);
                if (inputMenuString == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                if (!exceptionHandler.IsMatch(inputMenuString, Constant.Constant.REGISTRATION_MENU))   //2번까지 입력 가능하도록 예외처리
                {
                    continue;
                }
                menuNumber = int.Parse(inputMenuString);

                menuView.PrintRegistrationCourseMenu();
                switch (menuNumber) //메뉴 번호에 따라 기능 선택
                {
                    case 1:
                        
                        searchRegisteration.AddRegistrationFindLecture(studentIndex,true);
                        Console.ReadKey(true);
                        break;
                    case 2:
                        searchRegisteration.AddRegistrationInterestedLecture(studentIndex,true);
                        Console.ReadKey(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
