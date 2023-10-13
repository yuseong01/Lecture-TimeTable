using LTT.Model;
using LTT.Utility;
using LTT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller
{
    class LectureSearch
    {
        private LectureStudentData lectureStudentData;
        private LectureForm lectureSearchForm;
        private InputKey inputKey;
        private PaddingCalculator paddingCalculator;
        private LecturePrintForm lecturePrintForm;
        private Cursor cursor;
        private int firstIndex = -1, secondIndex = -1;
        private bool isChooseMode = true;
        private int subjectInfoIndex = 0;
        private string subjectName = "", professorName = "", grade = "", subjectNumber = "";

        public LectureSearch(LecturePrintForm lecturePrintForm, InputKey inputKey, LectureStudentData lectureStudentData, Cursor cursor) 
        {
            lectureSearchForm = new LectureForm();
            paddingCalculator = new PaddingCalculator();

            this.cursor = cursor;
            this.lectureStudentData = lectureStudentData;
            this.inputKey = inputKey;
            this.lecturePrintForm = lecturePrintForm;
        }

        
        public void FindCourse()       //강의 시간표 조회
        {
            Console.SetWindowSize(192,49);
            isChooseMode = true;

            Console.Clear();

            subjectInfoIndex = 0;
            subjectName = "";
            professorName = "";
            grade = "";
            subjectNumber = "";

            while (isChooseMode) {
                lectureSearchForm.SearchLectureInfo();
                lecturePrintForm.ShowlectureSearchList(subjectInfoIndex);

                ConsoleKeyInfo key = Console.ReadKey(true);
                
                //키보드유틸리티로
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:    //위 화살표
                        subjectInfoIndex--;
                        if (subjectInfoIndex <0 ) //0번째보다 작아지면 
                        {
                            subjectInfoIndex = 6;   //맨뒤에거 선택해줌
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        subjectInfoIndex++;    
                        if (subjectInfoIndex > 6)  //6번째보다 커지면
                        {
                            subjectInfoIndex = 0;   //맨앞에거 선택해줌
                        }
                        break;
                    case ConsoleKey.Enter:  //선택했으면
                        GetNumber(subjectInfoIndex);    //해당하는 번호의 행동을 위한 함수
                        break;
                    case ConsoleKey.Escape:
                        isChooseMode =false;
                        break;
                }
            }
        }
        private void GetNumber(int course)
        {
            switch (course)
            {
                case 0:
                    GetDepartment();    //개설학과 전공들을 보여주는 함수
                    break;
                case 1:
                    GetClassification(); //이수구분을 보여주는 함수
                    break;
                case 2:
                    Console.SetCursorPosition(20, 13);
                    subjectName = inputKey.EnterKey(false);
                    break;
                case 3:
                    Console.SetCursorPosition(20, 14);
                    professorName = inputKey.EnterKey(false);
                    break;
                case 4:
                    Console.SetCursorPosition(20, 15);
                    grade = inputKey.EnterKey(false);
                    break;
                case 5:
                    Console.SetCursorPosition(20, 16);
                    subjectNumber = inputKey.EnterKey(false);
                    break;
                case 6: //엔터키 누르면 해당하는 값을 보여줌
                    lectureSearchForm.SearchLecture(lectureStudentData, firstIndex, secondIndex, subjectName, professorName, grade, subjectNumber);
                    isChooseMode = false;
                    
                    break;
            }
        }
        private void GetDepartment()    //개설학과 전공을 보여주는 함수
        {
            firstIndex = -1;
            while (true)
            {
                Console.SetCursorPosition(20, 11);
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:  //왼쪽 키보드 누르면
                        firstIndex--;   //왼쪽으로 한칸감
                        if (firstIndex < 0) //0보다 작아지면
                        {
                            firstIndex = 4; //젤 오른쪽으로 감
                        }
                        break;
                    case ConsoleKey.RightArrow: //오른쪽 키보드 누르면
                        firstIndex++;       //오른쪽으로 한칸감
                        if (firstIndex > 4) //4보다 커지면
                        {
                            firstIndex = 0; //젤 왼쪽으로 감
                        }
                        break;
                    case ConsoleKey.Enter:
                        return;
                    case ConsoleKey.Escape:
                        firstIndex = -1;
                        return;
                }

                lecturePrintForm.ShowMajor(firstIndex);
            }
        }
        private void GetClassification()
        {
            secondIndex = -1;
            while (true)
            {
                Console.SetCursorPosition(20, 12);
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:     //왼쪽키보드로 누르면
                        secondIndex--;      //왼쪽으로 한칸감
                        if (secondIndex < 0)    //인덱스값보다 작아지면
                        {
                            secondIndex = 3;    //젤 오른쪽으로 감
                        }
                        break;
                    case ConsoleKey.RightArrow:     //오른쪽 키보드 누르면
                        secondIndex++;      //오른쪽으로 한칸감
                        if (secondIndex > 3)    //인덱스값보다 커지면
                        {
                            secondIndex = 0;    //젤 왼쪽으로 감
                        }
                        break;
                    case ConsoleKey.Enter:
                        return;
                    case ConsoleKey.Escape:
                        secondIndex = -1;
                        return;
                }
                lecturePrintForm.ShowMajorClassification(secondIndex);
            }
        }
    }
}
