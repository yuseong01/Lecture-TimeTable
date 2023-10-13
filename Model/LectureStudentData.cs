using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    class LectureStudentData
    {
        private List<Lectures> lectureList;
        private List<Student> studentList;
        private List<Lectures> searchLectureList;
        private string[,] timeTable;

        //set은 다른곳에서 따로 갱신하는게 아니여서 set빼야댐

        public List<Lectures> LectureList
        {
            get => lectureList;
        }
        public List<Student> StudentList
        {
            get => studentList;
        }
        public List<Lectures> SearchLectureList
        {
            get => searchLectureList;
        }
        public string[,] TimeTable
        {
            get => timeTable;
        }
        public LectureStudentData()
        {
            lectureList = new List<Lectures>();
            studentList = new List<Student>();
            searchLectureList =new List<Lectures>();
            timeTable = new string[27,5];
        }
    }
}
