using LTT.Main;
using LTT.Utility;
using LTT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    class LttMain
    {
        public static void Main(string[] args)
        {
            MainCourseSelection courseSelection= new MainCourseSelection();

            courseSelection.SelectCourse();
        }
    } 
}
