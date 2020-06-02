//解题关键为将日期压入栈，而不是将温度压入栈。利用压入栈的日期搜寻Temperature数组中代表的温度从而进行比较。
//创建一个数组res保存结果，初始状态全部刷成0。创建栈用于存储温度所对应的的日期。
//当栈不为空，并且当前遍历到的温度比栈顶日期所对应的的温度高时，设置index保存栈顶日期，并将栈顶弹出。
//更新res中index所对应的日期的值为当前日期day与index的差值。
//将当前日期day压入栈。
using System;
using System.Collections;

namespace DailyTemperatures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] T = { 73, 74, 75, 71, 69, 72, 76, 73 };
            DailyTemperatures(T);
        }
        static int[] DailyTemperatures(int[] T)
        {
            int[] res = new int[T.Length];
            Stack temDayStack = new Stack();
            for (int day = 0; day < T.Length; day++)
            {
                while (temDayStack.Count != 0 && T[day] > T[(int)temDayStack.Peek()])
                {
                    int index = (int)temDayStack.Peek();
                    temDayStack.Pop();
                    res[index] = day - index;
                }
                temDayStack.Push(day);
            }
            return res;
        }
    }
}
