using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LTT.Constant
{
    class Constant
    {
        public const int LECTURE_SEARCH = 1;
        public const int ADD_INTERESTSUBJECT = 2;
        public const int COURSE_REGISTRATION= 3;
        public const int TIMETABLE_SEARCH= 4;

        public const int ESC = -1;
        public const string ESC_STRING = "-1";

        //LTT
        public const string STUDENTID = @"^[0-9]{8}$";
        public const string STUDENTPW = @"^[0-9a-zA-Z]{6,10}$";
        public const string INPUTSTRING = @"^[0-9a-zA-Zㄱ-힇]$";
        public const string MAX_NUMBER =@"^[1-9]{1}$|^[1-9]{1}[0-9]{1}$|^[1]{1}[0-7]{1}[0-9]{1}$|^[1]{1}[8]{1}[0-4]{1}$";


        public const string DAY = @"^[ㄱ-힇]$";
        public const string TIME = @"^(0[1-9]|[0-5][0-9]):(0[1-9]|[0-5][0-9])$";
        public const string MENU = @"^[1-4]$";
        public const string REGISTRATION_MENU = @"^[1-2]$";

        public const int MON = 0;
        public const int TUE = 1;
        public const int WED = 2;
        public const int THU = 3;
        public const int FRI = 4;


    }
}
