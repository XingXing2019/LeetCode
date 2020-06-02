//双指针加状态机。
using System;

namespace LongestMountainInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 0, 1, 0, 0, 1, 1, 1, 1, 1 };
            Console.WriteLine(LongestMountain(A));
        }
        static int LongestMountain(int[] A)
        {
            if (A.Length < 3)
                return 0;
            const string up = "up";
            const string down = "down";
            const string start = "start";
            string status = start;
            int li = 0;
            int hi = 1;
            int len = 0;
            bool flag = false;
            for (; hi < A.Length; hi++)
            {
                if (A[hi] == A[hi - 1])
                {
                    if(flag)
                        len = Math.Max(len, hi - li);
                    li = hi;
                    status = start;
                    continue;
                }
                switch (status)
                {
                    case start:
                        status = A[hi] > A[hi - 1] ? up : down;
                        break;
                    case up:
                        if (A[hi] < A[hi - 1])
                        {
                            flag = true;
                            status = down;
                        }
                        break;
                    case down:
                        if (A[hi] > A[hi - 1])
                        {
                            status = up;
                            if (flag)
                            {
                                len = Math.Max(len, hi - li);
                                flag = false;
                            }
                            li = hi - 1;
                        }
                        break;
                }
            }
            if (status == down && flag)
                len = Math.Max(len, hi - li);
            return len;
        }
    }
}
