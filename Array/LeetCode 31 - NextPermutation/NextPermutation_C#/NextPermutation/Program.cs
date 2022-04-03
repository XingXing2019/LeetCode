//从后向前搜，找到第一个递减的位置，在从这个位置向后搜，找这个位置后面数字中，比这个位置大的最小数字，做交换，然后再将这个位置后面的数字排个序
using System;
using System.Collections.Generic;

namespace NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            NextPermutation1(nums);
        }
        static void NextPermutation1(int[] nums)
        {
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    int index = i + 1;
                    int min = nums[index];
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] > nums[i] && nums[j] < min)
                        {
                            min = nums[j];
                            index = j;
                        }
                    }
                    int tem = nums[i];
                    nums[i] = nums[index];
                    nums[index] = tem;
                    Array.Sort(nums, i + 1, nums.Length - i - 1);
                    return;
                }
            }
            Array.Sort(nums);
        }
        static void NextPermutation2(int[] nums)
        {
            List<int> store = new List<int>() { nums[nums.Length - 1] };
            int index = nums.Length - 2;
            while (index >= 0)
            {
                int tem = int.MinValue;
                for (int i = 0; i < store.Count; i++)
                {
                    if (store[i] > nums[index])
                    {
                        tem = store[i];
                        break;
                    }
                }
                if(tem > nums[index])
                {
                    store.Add(nums[index]);
                    nums[index++] = tem;
                    store.Remove(tem);
                    break;
                }
                else
                    store.Add(nums[index]);
                index--;
            }
            store.Sort();
            int pointer = 0;
            if (index < 0)
                index = 0;
            while (index < nums.Length)
                nums[index++] = store[pointer++];
        }
    }
}
