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
    class Login
    {
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private MenuView mainMenuView;
        private LectureStudentData lectureStudentData;
        private Cursor cursor;

        public Login(InputKey inputKey, ExceptionHandler exceptionHandler, MenuView mainMenuView, LectureStudentData lectureStudentData, Cursor cursor) 
        {
            this.cursor = cursor;
            this.inputKey= inputKey;
            this.exceptionHandler= exceptionHandler;
            this.mainMenuView= mainMenuView;
            this.lectureStudentData = lectureStudentData;
        }  
        public int GetLogin()
        {
            string inputString;
            int studentID;
            string password;
            bool isWorking = true;


            while (isWorking)
            {
                Console.Clear();
                mainMenuView.PrintLogin();
                //cursor.LimitCursor(60, 18, 18, 20);
                Console.SetCursorPosition(60, 18);
                inputString = inputKey.EnterKey(false);
                if (inputString == Constant.Constant.ESC_STRING)
                {
                    return -1;
                }
                else if (!exceptionHandler.IsMatch(inputString, Constant.Constant.STUDENTID))
                {
                    continue;
                }
                studentID = int.Parse(inputString);
                Console.SetCursorPosition(60, 20);
                inputString = inputKey.EnterKey(true);
                if (inputString == Constant.Constant.ESC_STRING)
                {
                    return -1;
                }
                else if(!exceptionHandler.IsMatch(inputString, Constant.Constant.STUDENTPW))
                {
                    continue;
                }
                password = inputString;
                for (int i = 0; i < lectureStudentData.StudentList.Count; i++)
                {
                    if (lectureStudentData.StudentList[i].Id == studentID&& lectureStudentData.StudentList[i].Password == password)
                    {
                        return i;
                    }
                }
    
            }

            return Constant.Constant.ESC;
        }
    }
}
