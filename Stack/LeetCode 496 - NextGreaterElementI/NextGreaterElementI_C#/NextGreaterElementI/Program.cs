//创建字典map记录nums1中每个数字的值和其在nums1中的下标。创建数组res接收结果。遍历res数组将所有元素刷成-1。同时将nums1中的元素及其下标记录如map。
//创建indexStack栈，用来记录下标。遍历nums2数组，如果当前数字在map中，证明其在nums1中出现过。则如果当前栈为空，则将其压栈。
//如果当前栈不为空，则在栈不为空，并且当前数字大于栈顶下标所指向nums2中数字的条件下，进行弹栈。
//并将获取所弹下标指向nums2中数字在nums1中的下标(从map字典中获取)。将此下标指向的res中的元素，设为当前所遍历到的数字。最后将当前nums2下标压栈。
//如果当前遍历到的始祖没有在nums1中出现，则操作和之前一样，唯一区别时弹栈结束后不讲当前下标压栈。
using System;
using System.Collections.Generic;
using System.Collections;

namespace NextGreaterElementI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 4, 1, 2 };
            int[] nums2 = { 1, 2, 3, 4 };
            Console.WriteLine(NextGreaterElement(nums1, nums2));
        }
        static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] res = new int[nums1.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = -1;
                map.Add(nums1[i], i);
            }
            Stack indexStack = new Stack();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (map.ContainsKey(nums2[i]))
                {
                    if (indexStack.Count == 0)
                        indexStack.Push(i);
                    else
                    {
                        while (indexStack.Count != 0 && nums2[i] > nums2[(int)indexStack.Peek()])
                        {
                            int index = map[nums2[(int)indexStack.Pop()]];
                            res[index] = nums2[i];
                        }
                        indexStack.Push(i);
                    }
                }
                else
                {
                    while (indexStack.Count != 0 && nums2[i] > nums2[(int)indexStack.Peek()])
                    {
                        int index = map[nums2[(int)indexStack.Pop()]];
                        res[index] = nums2[i];
                    }
                }
            }
            return res;
        }
    }
}
