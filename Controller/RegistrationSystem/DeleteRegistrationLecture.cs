using LTT.Model;
using LTT.Utility;
using LTT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller.RegistrationSystem
{
    class DeleteRegistrationLecture
    {
        private LecturePrintForm lecturePrintForm;
        private LectureStudentData data;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;

        public DeleteRegistrationLecture(LecturePrintForm lecturePrintForm, LectureStudentData data, InputKey inputKey, ExceptionHandler exceptionHandler)
        {
            this.lecturePrintForm = lecturePrintForm;
            this.data = data;
            this.inputKey = inputKey;
            this.exceptionHandler = exceptionHandler;
        }
        //함수 길이 김
        public void DeleteLecture(int studentId)
        {
            int lectureNumber;
            string inputNumber;
            string inputString;
            bool isInData = false;
            while (true)
            {
                //Console.Clear();
                lecturePrintForm.ShowRegistrationLecture(studentId, data);
                Console.WriteLine("=============================================================================================================================================================================================\n");
                isInData = false;

                Console.Write(" 등록가능 학점 : " + (21 - data.StudentList[studentId].RegisterationLectureCredit) + "     담은학점 : " + data.StudentList[studentId].RegisterationLectureCredit + "     삭제할과목 NO :                                ");
                Console.SetCursorPosition(Console.CursorLeft - 30, Console.CursorTop);

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


                for (int i = 0; i < data.StudentList[studentId].LectureRegistrationList.Count; i++)
                {
                    if (data.StudentList[studentId].LectureRegistrationList[i].Num == lectureNumber)
                    {
                        data.StudentList[studentId].LectureRegistrationList.Remove(data.StudentList[studentId].LectureRegistrationList[i]);
                        Console.WriteLine("\n신청과목 삭제 완료");
                        data.StudentList[studentId].RegisterationLectureCredit -= data.SearchLectureList[i].Credit;
                        isInData = true;
                    }
                }
                if (!isInData)
                {
                    Console.WriteLine("\n신청과목에 있는 과목의 번호를 입력해주세요:)");
                }

                Console.WriteLine("뒤로가기 : ESC | 계속하기 : ENTER");
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
