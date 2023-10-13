using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LTT.Utility
{  
    public class ExceptionHandler
    {
        public  bool IsMatch(string inputStirng, string checkString)
        { 
            Regex regex = new Regex(checkString);
            if (regex.IsMatch(inputStirng))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}