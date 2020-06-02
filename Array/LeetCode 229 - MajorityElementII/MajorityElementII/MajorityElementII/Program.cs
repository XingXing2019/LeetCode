//方法一：用字典统计每个数字出现的次数，最后获得出现超过要求的数字。
//方法二：因为要求超过1/3，则最多只可能有两个数字，最少为0个数字。所以可以用摩尔投票法。原理为，要想抵消掉某个数字，则其他数字出现次数一定要超过1/3.
//创建n1记录第一个可能的数字初始值为数组第一个数字，c1记录n1出现的次数，初始值设为1。n2记录第二个可能的数字，初始值设为0。c2记录n2的次数，初始值设为0。
//从第二个数字开始遍历。如果当前数字等于n1，则c1加一。如果等于n2，则c2加一。如果c1等于0，则替换n1，并将c1设为1。如果c2等于0，则替换n2，并将c2设为1。如果以上情况都不满足，则令c1和c2均减一。
//完成遍历后n1和n2就应该是可能满足要求的数字。还需要再遍历一遍数组，检查n1和n2出现的次数是否都超过1/3。
using System;
using System.Collections.Generic;

namespace MajorityElementII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2 };
            Console.WriteLine(MajorityElement(nums));
        }
        static IList<int> MajorityElement(int[] nums)
        {
            List<int> res = new List<int>();
            Dictionary<int, int> record = new Dictionary<int, int>();
            int amount = nums.Length / 3;
            foreach (var num in nums)
            {
                if (!record.ContainsKey(num))
                    record[num] = 1;
                else
                    record[num]++;
            }
            foreach (var kv in record)
            {
                if (kv.Value > amount)
                    res.Add(kv.Key);
            }
            return res;
        }
        static IList<int> MajorityElement2(int[] nums)
        {
            List<int> res = new List<int>();
            if (nums.Length == 0)
                return res;
            int n1 = nums[0], n2 = 0, c1 = 1, c2 = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == n1)
                    c1++;
                else if (nums[i] == n2)
                    c2++;
                else if (c1 == 0)
                {
                    n1 = nums[i];
                    c1 = 1;
                }
                else if(c2 == 0)
                {
                    n2 = nums[i];
                    c2 = 1;
                }
                else
                {
                    c1--;
                    c2--;
                }
            }
            c1 = 0;
            c2 = 0;
            foreach (var num in nums)
            {
                if (num == n1)
                    c1++;
                else if (num == n2)
                    c2++;
            }
            if (c1 > nums.Length / 3)
                res.Add(n1);
            if (c2 > nums.Length / 3)
                res.Add(n2);
            return res;
        }
    }
}
