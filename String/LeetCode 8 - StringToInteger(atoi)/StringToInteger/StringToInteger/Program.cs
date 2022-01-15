using System;

namespace StringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "0-1";
            Console.WriteLine(MyAtoi(str));
        }
        static int MyAtoi(string str)
        {
            str = str.Trim();
            if (str.Length == 0 || !char.IsDigit(str[0]) && (str[0] != '+' && str[0] != '-')) return 0;
            bool hasSign = false, hasDigit = false;
            string num = "";
            foreach (var letter in str)
            {
                if (letter == '+' || letter == '-')
                {
                    if (hasDigit) break;
                    if (hasSign) return 0;
                    num += letter;
                    hasSign = true;
                }
                else if (char.IsDigit(letter))
                {
                    num += letter;
                    hasDigit = true;
                }
                else
                    break;
            }
            if (num.Length == 1 && (num[0] == '+' || num[0] == '-')) return 0;
            if (int.TryParse(num, out var res))
                return res;
            return str[0] == '-' ? int.MinValue : int.MaxValue;
        }
    }
}
