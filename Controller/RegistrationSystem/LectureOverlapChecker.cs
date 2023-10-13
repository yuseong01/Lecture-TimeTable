using LTT.Model;
using LTT.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller.RegistrationSystem
{
    class LectureOverlapChecker
    {
        private LectureStudentData data;
        private InputKey inputKey;
        private ExceptionHandler exceptionHandler;
        public LectureOverlapChecker(LectureStudentData data, InputKey inputKey, ExceptionHandler exceptionHandler) 
        {
            this.data = data;
            this.inputKey = inputKey;
            this.exceptionHandler = exceptionHandler;
        
        }
        public int CalculateTimeinterval(string startTime)
        {
            int timeDifference;
            timeDifference = ChangeLength("08:00", startTime);

            return timeDifference;
        }
        public int ChangeLength(string time1, string time2)
        {
            DateTime dt1, dt2;
            TimeSpan timeDifference;
            int length;
            int hour, minute;

            dt1 = DateTime.ParseExact(time1, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            dt2 = DateTime.ParseExact(time2, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            timeDifference = dt2 - dt1;
            hour = timeDifference.Hours;
            minute = timeDifference.Minutes;

            length = hour * 2 + minute / 30;

            return length;
        }
        public int CalculateDay(string day)
        {
            switch(day)
            {
                case "월":
                    return 0;
                case "화":
                    return 1;
                case "수":
                    return 2;
                case "목":
                    return 3;
                case "금":
                    return 4;
            }
            return 0;
        }
        public bool ChangeTimeString(int lectureIndex)
        {
            string lectureTime = data.LectureList[lectureIndex].ClassTime;
            int day1, day2;
            string time1, time2;
            //string[,] timeTable = new string[27,5];
            int lectureLength, timeLength;
            //string registerLectureTime = data.StudentList[userIndex].LectureRegistrationList;
            switch (lectureTime.Length)
            {
                case 0 :
                    break;
                case 13 :
                    time1= lectureTime.Substring(2,5);
                    time2 = lectureTime.Substring(8,5);

                    lectureLength = ChangeLength(time1, time2);
                    timeLength = CalculateTimeinterval(time1);
                    day1= CalculateDay(lectureTime.Substring(0,1));

                    for (int i = 0; i < lectureLength; i++)
                    {
                        if (data.TimeTable[timeLength + i, day1]!=null)
                        {
                            return true;
                        }
                        else
                        {
                            data.TimeTable[timeLength + i, day1] = data.LectureList[lectureIndex].ClassName;
                        }
                    }
                    return false;
                    break;
                case 15 :

                    break;
                case 28:
                    break;
            }
            return false;
        }
    }
}
