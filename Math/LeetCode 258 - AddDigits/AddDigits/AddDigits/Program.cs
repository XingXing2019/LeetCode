//如果num小于10，则直接返回num。
//否则创建tem，将其设为num/10加上num%10，则对9取模。如果tem等于0，则将其设为9。最后返回tem。
using System;

namespace AddDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int AddDigits(int num)
        {
            if (num < 10)
                return num;
            int tem = (num / 10 + num % 10) % 9;
            if (tem == 0)
                tem = 9;
            return tem;
        }
    }
}
