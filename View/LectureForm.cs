using LTT.Model;
using LTT.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class LectureForm
    {
        private PaddingCalculator paddingCalculator;
        private LecturePrintForm lecturePrintForm;

        public LectureForm() 
        {
            paddingCalculator = new PaddingCalculator();
            lecturePrintForm = new LecturePrintForm();
        }
        public void SearchLectureInfo() //안내문구 출력
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("    ─────────────────────────────────────────*★*────────────────────────────────────────\n\n");
            Console.WriteLine("                                         [ 강의 검색 ]        §뒤로가기 :ESC           \n");
            Console.WriteLine("         ↑↓방향키로 옵션 이동 후 ENTER키를 누르면 선택 또는 입력이 가능합니다                     ");
            Console.WriteLine("         ←→방향키로 옵션 이동 후 ENTER키를 누르면 선택 가능합니다                                 ");
            Console.WriteLine("         검색 도중 ESC를 누르면 입력을 취소할 수 있습니다.                                          ");
            Console.WriteLine("         입력을 완료한 뒤에 <검색하기>에서 ENTER를 눌러주세요                                    ");
            Console.Write("\n    ────────────────────────────────────────*★*────────────────────────────────────────\n\n");
        }
        public void SearchLecture(LectureStudentData lectures, int firstIndex, int secondIndex, string subjectName, string professorName, string grade, string subjectNumber)
        {
            string[] major = new string[5] { "전체", "컴퓨터공학과", "소프트웨어학과", "지능기전공학부", "기계항공우주공학부" };
            string[] majorClassification = new string[4] { "전체", "공통교양필수", "전공필수", "전공선택" };

            Console.Clear();
            lecturePrintForm.ShowForm();

            lectures.SearchLectureList.Clear();

            for (int i = 0; i < lectures.LectureList.Count; i++)
            {
                if ((subjectName == "" || lectures.LectureList[i].ClassName == subjectName) &&
                    (professorName == "" || lectures.LectureList[i].Professor == professorName ) &&
                    (grade == "" || lectures.LectureList[i].Grade == int.Parse(grade)) &&
                    (subjectNumber == "" || lectures.LectureList[i].CourseNumber == int.Parse(subjectNumber)) &&
                    (firstIndex == 0 || firstIndex == -1 || lectures.LectureList[i].Major == major[firstIndex]) &&
                    (secondIndex == 0 || secondIndex == -1 || lectures.LectureList[i].SubjectType == majorClassification[secondIndex]))
                {
                    lecturePrintForm.ShowSchedule(lectures.LectureList[i]);
                    lectures.SearchLectureList.Add(lectures.LectureList[i]);
                }
            }
        }
    }
}
