using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    class Lectures
    {
        private int num;    //NO
        private string major;   //개설학과전공
        private int courseNumber;   //학수번호
        private string classNumber;    //분반
        private string className; //교과목명
        private string subjectType; //이수구분
        private int grade;  //학년
        private int credit; //학점
        private string classTime; //요일 및 강의시간
        private string classLocation;  //강의실
        private string professor; //메인교수명 
        private string language; //강의 언어
        private List<string> day;
        private List<int> time;

        public Lectures(int num, string major, int courseNumber, string classNumber, string className, string subjectType, int grade, int credit, string classTime, string classLocation, string professor, string language)
        {
            this.num = num;
            this.major = major;
            this.courseNumber = courseNumber;
            this.classNumber = classNumber;
            this.className = className;
            this.subjectType = subjectType;
            this.grade = grade;
            this.credit = credit;
            this.classTime = classTime;
            this.classLocation = classLocation;
            this.professor = professor;
            this.language = language;
            day = new List<string>();
            time = new List<int>();
        }

        public int Num
        {
            get => num;
        }
        public string Major
        {
            get => major;
        }
        public int CourseNumber
        {
            get => courseNumber;
        }
        public string ClassNumber
        {
            get => classNumber;
        }
        public string ClassName
        {
            get => className;
        }
        public string SubjectType
        {
            get => subjectType;
        }
        public int Grade
        {
            get => grade;
        }
        public int Credit
        {
            get => credit;
        }
        public string ClassTime
        {
            get => classTime;
        }
        public string ClassLocation
        {
            get => classLocation;
        }
        public string Professor
        {
            get => professor;
        }
        public string Language
        {
            get => language;
        }
        public List<string> Day
        {
            get => this.day;
            set => this.day = value;
        }
        public List<int> Time
        {
            get => this.time;
            set => this.time = value;
        }
    }
}
