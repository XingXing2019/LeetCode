//创建字典保存int和Roman的键值对，创建一个数组nums保存每个Roman所代表的的数字。
//先将一个Roman所代表的的数字存入数组，从字符串第二个Roman开始遍历字符串s，先将每个Roman在字典中int的映射保存在数组nums中。
//如果当前Roman代表的数字比上一个Roman代表的数字大，则将上一个Roman代表的数字取反。
//结束字符串s遍历后，nums数组中所有数字相加的和即为结果。
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "IVV";
            Console.WriteLine(RomanToInt(s));
        }
        static int RomanToInt(string s)
        {
            if (s == "")
                return 0;
            Dictionary<char, int> romanIntDic = new Dictionary<char, int>();
            romanIntDic.Add('I', 1);
            romanIntDic.Add('V', 5);
            romanIntDic.Add('X', 10);
            romanIntDic.Add('L', 50);
            romanIntDic.Add('C', 100);
            romanIntDic.Add('D', 500);
            romanIntDic.Add('M', 1000);
            int[] nums = new int[s.Length];
            nums[0] = romanIntDic[s[0]];
            for (int i = 1; i < s.Length; i++)
            {
                nums[i] = romanIntDic[s[i]];
                if (romanIntDic[s[i]] > romanIntDic[s[i - 1]])
                    nums[i - 1] = -nums[i - 1];
            }
            return nums.Sum(num => num);
        }
    }
}
