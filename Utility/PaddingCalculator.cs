using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Utility
{
    class PaddingCalculator
    {
        private int GetPadCount(string str, int length)
        {
            int totalBytes = Encoding.Default.GetByteCount(str.PadRight(length));   //length만큼 확보한 길이
            int difference = totalBytes - length;   //원래 원했던 길이와 확보한 길이의 차이

            return length - difference;
        }

        public string GetPadRight(string str, int length)   //문자열 칸만큼 보정한 결과를 반환 
        {
            int padCount = GetPadCount(str, length);
            string result = str.PadRight(padCount);

            return result;
        }
    }
}
