//创建res数组接收结果，将所有元素刷成-1。创建indexStack栈用来存储数字的下标。先将数组第一个数字压栈。
//从数组第二个数字开始遍历，如果当前数字大于栈顶下标所指向的数字，则在栈不为空且当前数字大于栈顶下标指向的数字的情况下，进行弹栈，并将弹出下标所指向res中的元素设为当前遍历到的数字。
//结束弹栈后，如果栈不为空，并且当前遍历到的下标和栈顶下标相同，终止遍历。否则将当前下标压栈。
//如果当前数字不大于栈顶下标所指向的数字，则在栈不为空，并且当前遍历到的下标和栈顶下标相同时，终止遍历。否则将当前下标压栈。
//当遍历到最后一个元素时，时i等于i - len，则进入下一次遍历时i会加一并指向第一个元素。
//当栈內元素多于数组长度时，证明所有元素都已经遍历了一次，则终止遍历。
//最后返回res。
using System;
using System.Collections;

namespace NextGreaterElementII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2 };
            Console.WriteLine(NextGreaterElements(nums));
        }
        static int[] NextGreaterElements(int[] nums)
        {
            int len = nums.Length;
            int[] res = new int[len];
            for (int i = 0; i < res.Length; i++)
                res[i] = -1;
            Stack indexStack = new Stack();
            indexStack.Push(0);
            for (int i = 1; i < len; i++)
            {
                if (nums[i] > nums[(int)indexStack.Peek()])
                {
                    while (indexStack.Count != 0 && nums[i] > nums[(int)indexStack.Peek()])
                    {
                        res[(int)indexStack.Pop()] = nums[i];
                    }
                    if (indexStack.Count != 0 && i == (int)indexStack.Peek())
                        break;
                    else
                        indexStack.Push(i);
                }
                else
                {
                    if (indexStack.Count != 0 && i == (int)indexStack.Peek())
                        break;
                    else
                        indexStack.Push(i);
                }
                if (i == len - 1)
                    i -= len;
                if (indexStack.Count > len)
                    break;
            }
            return res;
        }
    }
}
