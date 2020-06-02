//思路与LeetCode 69相似。使用二分搜索。
//创建li和hi分别指向1和num。在li小于hi的条件下循环，获得li和hi的中值mid。如果mid的平方等于num则返回true。
//如果mid的平方大于num，则使hi指向mid。否则使li指向mid + 1。
//循环结束后如仍返回true，证明没有一个mid满足条件，则返回false。
using System;

namespace ValidPerfectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            Console.WriteLine(IsPerfectSquare(num));
        }
        static bool IsPerfectSquare(int num)
        {
            if (num == 1)
                return true;
            int li = 1;
            int hi = num;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (mid * mid == num)
                    return true;
                else if (num / mid < mid)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return false;
        }
    }
}
