using LTT.Model;
using LTT.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class LecturePrintForm
    {
        private PaddingCalculator paddingCalculator;

        public LecturePrintForm()
        {
            paddingCalculator = new PaddingCalculator();
        }

        public void ShowForm()
        {
            string[] list = new string[12] { "NO", "개설학과전공", "학수번호", "분반", "교과목명", "이수구분", "학년", "학점", "요일 및 시간", "강의실", "메인교수명", "강의언어" };

            Console.WriteLine("=============================================================================================================================================================================================\n");
            Console.WriteLine(paddingCalculator.GetPadRight(list[0], 5) + paddingCalculator.GetPadRight(list[1], 18) + paddingCalculator.GetPadRight(list[2], 9) +
               paddingCalculator.GetPadRight(list[3], 9) + paddingCalculator.GetPadRight(list[4], 33) + paddingCalculator.GetPadRight(list[5], 11) +
               paddingCalculator.GetPadRight(list[6], 2) + paddingCalculator.GetPadRight(list[7], 5) + paddingCalculator.GetPadRight(list[8], 34) +
               paddingCalculator.GetPadRight(list[9], 19) + paddingCalculator.GetPadRight(list[10], 29) + paddingCalculator.GetPadRight(list[11], 15));
            Console.WriteLine("=============================================================================================================================================================================================\n");
        }
        public void ShowSchedule(Lectures lectures)
        {
             Console.WriteLine(paddingCalculator.GetPadRight(lectures.Num.ToString(), 5)
                    + paddingCalculator.GetPadRight(lectures.Major, 20) +
                    paddingCalculator.GetPadRight(lectures.CourseNumber.ToString(), 8) +
              paddingCalculator.GetPadRight(lectures.ClassNumber.ToString(), 5)
              + paddingCalculator.GetPadRight(lectures.ClassName, 34)
              + paddingCalculator.GetPadRight(lectures.SubjectType, 15) +
              paddingCalculator.GetPadRight(lectures.Grade.ToString(), 3)
              + paddingCalculator.GetPadRight(lectures.Credit.ToString(), 3)
              + paddingCalculator.GetPadRight(lectures.ClassTime, 35) +
              paddingCalculator.GetPadRight(lectures.ClassLocation, 20)
              + paddingCalculator.GetPadRight(lectures.Professor, 28)
              + paddingCalculator.GetPadRight(lectures.Language, 15));
        }
        public void ShowInterestedLecture(int studentId,LectureStudentData data)
        {
            Console.Clear();
            ShowForm();
            for (int i = 0; i < data.StudentList[studentId].InterestedlectureList.Count; i++)
            {
                ShowSchedule(data.StudentList[studentId].InterestedlectureList[i]);
            }
        }
        public void ShowRegistrationLecture(int studentId, LectureStudentData data)
        {
            Console.Clear();
            ShowForm();
            for (int i = 0; i < data.StudentList[studentId].LectureRegistrationList.Count; i++)
            {
                ShowSchedule(data.StudentList[studentId].LectureRegistrationList[i]);
            }
        }
        public void ShowlectureSearchList(int subjectInfoIndex)
        {
            string[] lectureSearchList = new string[7] { "   ℓ 개설학과전공 :", "   ℓ 이수구분     :", "   ℓ 교과목명     :", "   ℓ 교수명       :", "   ℓ 학년         :", "   ℓ 학수번호     :", "   < 검색하기 >" };

            for (int j = 0; j < lectureSearchList.Length; j++)  //선택된 인덱스 색 바꿔줌
            {
                if (j == subjectInfoIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(paddingCalculator.GetPadRight(lectureSearchList[j], 15));
                Console.ResetColor();
            }
        }
        public void ShowMajor(int firstIndex)
        {
            string[] major = new string[5] { "전체", "컴퓨터공학과  ", "소프트웨어학과  ", "지능기전공학부  ", "기계항공우주공학부  " };

            for (int j = 0; j < major.Length; j++)  //선택된 인덱스 색 바꿔줌
            {
                if (j == firstIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(paddingCalculator.GetPadRight(major[j], 10));
                Console.ResetColor();
            }
        }
        public void ShowMajorClassification(int secondIndex)
        {
            string[] majorClassification = new string[4] { "전체", "교양필수", "전공필수", "전공선택" };

            for (int j = 0; j < majorClassification.Length; j++)
            {
                if (j == secondIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(paddingCalculator.GetPadRight(majorClassification[j], 12));
                Console.ResetColor();
            }
        }
    }
}
