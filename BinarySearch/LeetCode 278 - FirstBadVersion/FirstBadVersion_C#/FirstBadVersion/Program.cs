using System;

namespace FirstBadVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int FirstBadVersion(int n)
        {
            int li = 1, hi = n;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (IsBadVersion(mid))
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }

        static bool IsBadVersion(int version)
        {
            return true;
        }
    }
}
