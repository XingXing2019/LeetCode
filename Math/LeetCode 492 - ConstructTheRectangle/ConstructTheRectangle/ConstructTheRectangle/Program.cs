//先找到area的平方根squareRoot，并把它变成一个int型。从squareRoot向回遍历。第一个能被area整除的数字为W, 被area除的结果为L。
using System;

namespace ConstructTheRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] ConstructRectangle(int area)
        {
            int[] res = new int[2];
            int squareRoot = (int)Math.Sqrt(area);
            for (int i = squareRoot; i >= 0; i--)
            {
                if(area % i == 0)
                {
                    res[0] = area / i;
                    res[1] = i;
                    break;
                }
            }
            return res;
        }
    }
}
