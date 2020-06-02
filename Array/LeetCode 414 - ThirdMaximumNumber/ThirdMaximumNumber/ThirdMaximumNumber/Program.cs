//创建一个record列表记录三个最大的数字，始终维持record的长度不大于3，这样可以保证时间复杂度为O(3)。
//遍历数组，对于每一个数字，如果其不在record中，则在record长度小于3时，将其加入record。当record长度不小于3时，则遍历record，找出其中最小的数字，如果该数字比当前数字小，则将其从record中删除，并将当前数字加入。
//遍历结束后，对record排序，如果record长度为3则返回其第一个数字，否则返回最后一个数字。
using System;
using System.Collections.Generic;

namespace ThirdMaximumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 2, 4, 1, 3, 6, 0 };
            Console.WriteLine(ThirdMax(nums));
        }
        static int ThirdMax(int[] nums)
        {
            List<int> record = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!record.Contains(nums[i]))
                {
                    if (record.Count < 3)
                        record.Add(nums[i]);
                    else
                    {
                        int min = int.MaxValue;
                        for (int j = 0; j < record.Count; j++)
                            min = Math.Min(min, record[j]);
                        if(min < nums[i])
                        {
                            record.Remove(min);
                            record.Add(nums[i]);
                        }
                        
                    }
                }
            }
            record.Sort();
            if (record.Count == 3)
                return record[0];
            else
                return record[record.Count-1];
        }
    }
}
