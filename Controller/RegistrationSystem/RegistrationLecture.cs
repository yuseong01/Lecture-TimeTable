using LTT.Model;
using LTT.Utility;
using LTT.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller.RegistrationSystem
{
    internal class RegistrationLecture
    {
        private LectureSearch lectureSearch;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private LectureStudentData data;
        private LecturePrintForm lecturePrintForm;
        private LectureOverlapChecker lectureOverlapChecker;
        private bool isExceedCredit = false,isInData = false;

        public RegistrationLecture(LectureSearch lectureSearch, InputKey inputKey, LectureStudentData data, ExceptionHandler exceptionHandler, LecturePrintForm lecturePrintForm)
        {
            this.lectureSearch = lectureSearch;
            this.inputKey = inputKey;
            this.data = data;
            this.exceptionHandler = exceptionHandler;
            this.lecturePrintForm = lecturePrintForm;
            lectureOverlapChecker = new LectureOverlapChecker(data, inputKey, exceptionHandler);
        }
        public bool CheckExist(int userIndex, int lectureNumber)
        {
            for (int i = 0; i < data.StudentList[userIndex].LectureRegistrationList.Count; i++)
            {
                if (data.StudentList[userIndex].LectureRegistrationList[i].Num == lectureNumber)
                {
                    return  false;
                }
            }
            return true;
        }
        public void Register(int userIndex, Lectures lecture, int lectureNumber, bool isInterestedLecture)
        {
            bool isNull = lectureOverlapChecker.ChangeTimeString(userIndex);

            //if (isNull == true)
            //{
                if (lectureNumber == lecture.Num)
                {
                    if (data.StudentList[userIndex].RegisterationLectureCredit + lecture.Credit > 21)
                    {
                        isExceedCredit = true;
                    }
                    else
                    {
                        data.StudentList[userIndex].LectureRegistrationList.Add(lecture);
                        Console.WriteLine("\n수강신청 정상 완료");
                        data.StudentList[userIndex].RegisterationLectureCredit += lecture.Credit;
                        if (isInterestedLecture)
                        {
                            data.StudentList[userIndex].InterestedlectureList.Remove(lecture);
                        }
                        isInData = true;
                    }
                }
                //else
                //{
                //    Console.WriteLine("겹치는 과목이 존재합니다");
                //}
            //}
           
        }
        public void AddRegistrationInterestedLecture(int userIndex, bool isNormal)
        {
            string inputNumber;
            int lectureNumber;
            bool isNotInList = true;
            string inputString;


            while (true)
            {
                isExceedCredit = false;
                isInData = false;
                isNotInList = true;
                bool isOverlap = false;

                Console.Clear();

                lecturePrintForm.ShowInterestedLecture(userIndex, data);
                Console.WriteLine("=============================================================================================================================================================================================\n");

                Console.Write(" 신청가능 학점 : " + (21 - data.StudentList[userIndex].RegisterationLectureCredit) + "     수강학점 : " + data.StudentList[userIndex].RegisterationLectureCredit + "     수강신청 NO :      ");
                Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop);

                inputNumber = inputKey.EnterKey(false);
                if (inputNumber == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                if (!exceptionHandler.IsMatch(inputNumber, Constant.Constant.MAX_NUMBER)) //184번까지 입력하도록 예외처리
                {
                    continue;
                }
                lectureNumber = int.Parse(inputNumber);

                isNotInList = CheckExist(userIndex, lectureNumber);

                isOverlap = lectureOverlapChecker.ChangeTimeString(lectureNumber);

                if (!isOverlap)
                {
                    if (isNotInList)
                    {
                        for (int i = 0; i < data.StudentList[userIndex].InterestedlectureList.Count; i++)
                        {
                            Register(userIndex, data.StudentList[userIndex].InterestedlectureList[i], lectureNumber, true);
                        }
                    }
                }

                if (!isInData)
                {
                    if (isExceedCredit)
                    {
                        Console.WriteLine("\n가능 학점을 초과하였습니다:)");
                    }
                    else
                    {
                        Console.WriteLine("\n번호를 다시 입력해주세요:)");
                    }
                }
                Console.WriteLine("뒤로가기 : ESC | 계속담기 : ENTER");
                inputString = inputKey.EnterKey(false);
                if (inputString == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("                                                                                                      ");
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine("                                                                                                      ");
                Console.SetCursorPosition(0, Console.CursorTop - 2);
            }
        }
        public void AddRegistrationFindLecture(int userIndex, bool isNormal)
        {
            int lectureNumber;
            string inputRegisterLectureNumber;
            string inputString;
            bool isNotInList = true;
            bool isOverlap = false;

            Console.Clear();

            lectureSearch.FindCourse();
            Console.WriteLine("=============================================================================================================================================================================================\n");

            while (true)
            {
                isExceedCredit = false;
                isInData = false;
                isNotInList = true;

                Console.Write(" 신청가능 학점 : " + (21 - data.StudentList[userIndex].RegisterationLectureCredit) + "     수강학점 : " + data.StudentList[userIndex].RegisterationLectureCredit + "     수강신청 NO :                                ");
                Console.SetCursorPosition(Console.CursorLeft - 30, Console.CursorTop);

                inputRegisterLectureNumber = inputKey.EnterKey(false);
                if (inputRegisterLectureNumber == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                if (!exceptionHandler.IsMatch(inputRegisterLectureNumber, Constant.Constant.MAX_NUMBER)) //184번까지 입력하도록 예외처리
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    continue;
                }
                lectureNumber = int.Parse(inputRegisterLectureNumber);


                isNotInList = CheckExist(userIndex, lectureNumber);

                isOverlap = lectureOverlapChecker.ChangeTimeString(lectureNumber);
                //
                for (int i = 0; i < data.StudentList[userIndex].LectureRegistrationList.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(data.TimeTable[i,j]);
                    }
                    Console.WriteLine("\n");
                }
                //
                if (!isOverlap)
                {
                    if (isNotInList)
                    {
                        for (int i = 0; i < data.SearchLectureList.Count; i++)
                        {
                            Register(userIndex, data.SearchLectureList[i], lectureNumber, false);
                        }
                    }
                }

                if (!isInData)
                {
                    if (isExceedCredit)
                    {
                        Console.WriteLine("\n가능 학점을 초과하였습니다:)");
                    }
                    else
                    {
                        Console.WriteLine("\n번호를 다시 입력해주세요:)");
                    }
                }
                Console.WriteLine("뒤로가기 : ESC | 계속담기 : ENTER");
                inputString = inputKey.EnterKey(false);
                if (inputString == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("                                                                                                      ");
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine("                                                                                                      ");
                Console.SetCursorPosition(0, Console.CursorTop - 2);
            }
        }
    }
}

