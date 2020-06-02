//用一个Stack实现一个单调栈。目的是找到尽可能靠前的较小的数字。
//遍历A，如果当前数字小于栈顶数字，则将当前数字的index压栈。
//然后倒着遍历A，在栈不为空，且当前数字大于等于栈顶时(因为当前栈顶之下没有再小的数字了)，更新res，并将栈顶弹出。
using System;
using System.Collections.Generic;

namespace MaximumWidthRamp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 9, 8, 1, 0, 1, 9, 4, 0, 4, 1 };
            Console.WriteLine(MaxWidthRamp(A));
        }
        static int MaxWidthRamp(int[] A)
        {
            int res = 0;
            Stack<int> record = new Stack<int>();
            record.Push(0);
            for (int i = 1; i < A.Length; i++)
                if(A[record.Peek()] > A[i])
                    record.Push(i);
            for (int i = A.Length-1; i >= 0; i--)
                while (record.Count!= 0 && A[i] >= A[record.Peek()])
                    res = Math.Max(res, i - record.Pop());
            return res;
        }
    }
}
