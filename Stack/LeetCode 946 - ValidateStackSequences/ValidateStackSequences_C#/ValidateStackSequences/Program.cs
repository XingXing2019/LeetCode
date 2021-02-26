//创建record栈辅助push和pop操作。创建pushIndex和popIndex指针用于遍历两个数组。
//在pushIndex和popIndex不越界的条件下遍历。将pushIndex指向的数字压栈，并使pushIndex移动一位。
//当栈不为空，popIndex不越界，并且popIndex指向数字和栈顶数字相同的条件下，循环弹栈，并使popIndex移动一位.
//最后返回record栈是否为空。
using System;
using System.Collections;

namespace ValidateStackSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pushed = { 1, 0 };
            int[] poped = {1,0 };
            Console.WriteLine(ValidateStackSequences(pushed, poped));
        }
        static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack record = new Stack();
            int pushIndex = 0;
            int popInddex = 0;
            while (pushIndex < pushed.Length && popInddex < popped.Length)
            {
                record.Push(pushed[pushIndex]);
                pushIndex++;
                while(record.Count != 0 && popInddex < popped.Length && popped[popInddex] == (int)record.Peek())
                {
                    record.Pop();
                    popInddex++;
                }
            }
            return record.Count == 0;
        }
    }
}
