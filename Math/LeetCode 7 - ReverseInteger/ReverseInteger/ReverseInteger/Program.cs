using System;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int Reverse(int x)
        {
            int tem = x > 0 ? x : -x;
            string str = tem.ToString();
            string resStr = "";
            for (int i = str.Length - 1; i >= 0; i--)
                resStr += str[i];            
            int res;
            bool isValid = int.TryParse(resStr, out res);
            return x > 0 ? res : -res;
        }
    }
}
