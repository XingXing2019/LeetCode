//花里胡哨，相遇掉头可以理解成穿过彼此继续往前走。所以结果就看两队蚂蚁的最后一个什么时候掉下去。
using System;

namespace LastMoment
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            int[] left = { };
            int[] right = {0, 1, 2, 3, 4, 5, 6, 7};
            Console.WriteLine(GetLastMoment(n, left, right));
        }
        static int GetLastMoment(int n, int[] left, int[] right)
        {
            Array.Sort(left);
            Array.Sort(right);
            int leftLast = left.Length == 0 ? 0 : left[^1];
            int rightLast = right.Length == 0 ? 0 : n - right[0];
            return Math.Max(leftLast, rightLast);
        }
    }
}
