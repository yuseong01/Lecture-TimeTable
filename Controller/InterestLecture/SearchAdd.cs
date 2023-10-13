using LTT.Model;
using LTT.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller.InterestLecture
{
    class SearchAdd
    {
        private LectureSearch lectureSearch;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        private LectureStudentData data;

        public SearchAdd(LectureSearch lectureSearch, InputKey inputKey, LectureStudentData data, ExceptionHandler exceptionHandler) 
        {
            this.lectureSearch = lectureSearch;
            this.inputKey = inputKey;
            this.data = data;
            this.exceptionHandler = exceptionHandler;
        }
        public void AddInterestedLecture(int userIndex)
        {
            int lectureNumber;
            string inputNumber;
            string inputString;
            bool isInData=false, isNotInList=true, isExceedCredit=false;

            Console.Clear();

            lectureSearch.FindCourse();
            Console.WriteLine("=============================================================================================================================================================================================\n");

            while (true) {
                isInData = false;
                isNotInList = true;
                isExceedCredit = false;

                //Console.Clear();

                Console.Write(" 등록가능 학점 : "+(24- data.StudentList[userIndex].InterestedLectureCredit) +"     담은학점 : " + data.StudentList[userIndex].InterestedLectureCredit + "     담을과목 NO :                                ");
                Console.SetCursorPosition(Console.CursorLeft - 30, Console.CursorTop);
                
                inputNumber = inputKey.EnterKey(false);
                if (inputNumber == Constant.Constant.ESC_STRING)
                {
                    return;
                }
                if (!exceptionHandler.IsMatch(inputNumber, Constant.Constant.MAX_NUMBER)) //184번까지 입력하도록 예외처리
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    continue;
                }

                lectureNumber = int.Parse(inputNumber);
                

                for (int j = 0; j < data.StudentList[userIndex].InterestedlectureList.Count; j++)
                {
                    if (data.StudentList[userIndex].InterestedlectureList[j].Num == lectureNumber)
                    {
                        isNotInList = false;
                    }
                }
                if (isNotInList)
                {
                    for (int i = 0; i < data.SearchLectureList.Count; i++)
                    {
                        if (lectureNumber == data.SearchLectureList[i].Num)
                        {
                            if (data.StudentList[userIndex].InterestedLectureCredit + data.SearchLectureList[i].Credit > 24)
                            {
                                isExceedCredit = true;
                            }
                            else
                            {
                                data.StudentList[userIndex].InterestedlectureList.Add(data.SearchLectureList[i]);
                                Console.WriteLine("\n관심과목 담기 완료");
                                data.StudentList[userIndex].InterestedLectureCredit += data.SearchLectureList[i].Credit;
                                isInData = true;
                            }
                        }
                    }
                }
               
                if(!isInData)
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
