using System;

namespace CountSymmetricIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountSymmetricIntegers(int low, int high)
        {
            var res = 0;
            for (int i = low; i <= high; i++)
            {
                if (IsSymmetric(i.ToString()))
                    res++;
            }
            return res;
        }

        public bool IsSymmetric(string num)
        {
            if (num.Length % 2 != 0)
                return false;
            int li = 0, hi = num.Length - 1;
            int front = 0, back = 0;
            while (li < hi)
            {
                front += num[li++];
                back += num[hi--];
            }
            return front == back;
        }
    }
}
