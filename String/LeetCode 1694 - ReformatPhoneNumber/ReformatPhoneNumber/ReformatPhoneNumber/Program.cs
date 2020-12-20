using System;

namespace ReformatPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string ReformatNumber(string number)
        {
            var num = "";
            foreach (var letter in number)
            {
                if (char.IsDigit(letter))
                    num += letter;
            }
            if (num.Length <= 4)
                return num.Length == 4 ? $"{num.Substring(0, 2)}-{num.Substring(2, 2)}" : num;
            var res = "";
            int len = 0;
            for (int i = 0; i < num.Length - 2; i++)
            {
                len++;
                res += num[i];
                if (len % 3 == 0)
                    res += '-';
            }
            if (len % 3 == 2) res += "-";
            res += num.Substring(num.Length - 2);
            return res;
        }
    }
}
