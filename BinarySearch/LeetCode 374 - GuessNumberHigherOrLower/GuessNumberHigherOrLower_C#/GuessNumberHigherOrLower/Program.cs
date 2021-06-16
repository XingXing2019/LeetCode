using System;

namespace GuessNumberHigherOrLower
{
    
    class Program
    {
        int guess(int num)
        {
            return 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int GuessNumber(int n)
        {
            int li = 1, hi = n;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (guess(mid) == 0)
                    return mid;
                if (guess(mid) == -1)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
