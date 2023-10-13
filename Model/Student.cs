using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    class Student
    {
        private int id;
        private string password;
        private int interestedLectureCredit;
        private int registerationLectureCredit;
        private List<Lectures> interestedLectureList;
        private List<Lectures> lectureRegistrationList;

        public Student(int id, string password,int credit,int registerationLectureCredit) 
        {
            this.id = id;  
            this.password = password;
            this.interestedLectureCredit = credit;
            this.registerationLectureCredit=registerationLectureCredit;
            interestedLectureList = new List<Lectures>();
            lectureRegistrationList = new List<Lectures>();
        }

        public int Id
        {
            get => this.id;
        }
        public string Password
        {
            get => this.password;
        }
        public int InterestedLectureCredit
        {
            get => this.interestedLectureCredit;
            set => this.interestedLectureCredit = value;
        }
        public int RegisterationLectureCredit
        {
            get => this.registerationLectureCredit;
            set => this.registerationLectureCredit = value;
        }
        public List<Lectures> InterestedlectureList
        {
            get => this.interestedLectureList;
            set => this.interestedLectureList = value;
        }
        public List<Lectures> LectureRegistrationList
        {
            get => this.lectureRegistrationList;
            set => this.lectureRegistrationList = value;
        }
    }
    

}
