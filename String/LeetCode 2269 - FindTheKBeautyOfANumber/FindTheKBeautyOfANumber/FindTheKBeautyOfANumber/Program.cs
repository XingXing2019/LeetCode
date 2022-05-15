using System;

namespace FindTheKBeautyOfANumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int DivisorSubstrings(int num, int k)
        {
            var numsStr = num.ToString();
            var res = 0;
            for (int i = 0; i <= numsStr.Length - k; i++)
            {
                var subNum = int.Parse(numsStr.Substring(i, k));
                if (subNum == 0) continue;
                if (num % subNum == 0)
                    res++;
            }
            return res;
        }
    }
}
