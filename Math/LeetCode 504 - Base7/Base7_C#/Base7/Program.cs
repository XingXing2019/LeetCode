//当num为0时，直接返回"0"。
//否则先将num取绝对值absNum。创建res接收结果。
//在absNum不为0 的条件下循环，将absNum与7的余数反向加入res，再将absNum对7整除。
//如果num为负数，则在res前加上负号，最后返回res。
using System;

namespace Base7
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = -7;
            Console.WriteLine(ConvertToBase7(num));
            
        }
        static string ConvertToBase7(int num)
        {
            if (num == 0)
                return "0";
            string res = "";
            int absNum = Math.Abs(num);
            while (absNum != 0)
            {
                res = absNum % 7 + res;
                absNum /= 7;
            }
            if (num < 0)
                res = "-" + res;
            return res;
        }
    }
}
