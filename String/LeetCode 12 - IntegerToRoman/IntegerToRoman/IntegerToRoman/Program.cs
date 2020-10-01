//创建字典保存Roman和int的键值对。设立digit代表位数。设立res保存结果。
//在num不为0时循环。num对10取模得到最后一个数字，根据数字的值对res做出相应操作，需注意4，9和大于5的数字应作特殊处理。
//一次循环后num对10整除以去掉最后一位，同时digit乘10以调整当前数位。
using System;
using System.Collections.Generic;

namespace IntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string IntToRoman(int num)
        {
            if (num == 0)
                return "";
            Dictionary<int, string> intRomanDic = new Dictionary<int, string>();
            intRomanDic.Add(1, "I");
            intRomanDic.Add(5, "V");
            intRomanDic.Add(10, "X");
            intRomanDic.Add(50, "L");
            intRomanDic.Add(100, "C");
            intRomanDic.Add(500, "D");
            intRomanDic.Add(1000, "M");

            int digit = 1;
            string res = "";
            while (num != 0)
            {
                int current = num % 10;
                if (current == 4)
                    res = intRomanDic[digit] + intRomanDic[digit * 5] + res;
                else if (current == 9)
                    res = intRomanDic[digit] + intRomanDic[digit * 10] + res;
                else
                {
                    for (int i = 0; i < current % 5; i++)
                        res = intRomanDic[digit] + res;
                    if (current / 5 > 0)
                        res = intRomanDic[digit * 5] + res;
                }
                num /= 10;
                digit *= 10;
            }
            return res;
        }
        static string IntToRoman_2(int num)
        {
            int[] nums = { 1000, 500, 100, 50, 10, 5, 1 };
            char[] letters = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            var res = "";
            for (int i = 0; i < nums.Length; i += 2)
            {
                var count = num / nums[i];
                if (count == 4)
                    res += $"{letters[i]}{letters[i - 1]}";
                else if (count >= 5 && count < 9)
                    res += $"{letters[i - 1]}{new string(letters[i], Math.Max(0, count - 5))}";
                else if (count == 9)
                    res += $"{letters[i]}{letters[i - 2]}";
                else
                    res += new string(letters[i], count);
                num %= nums[i];
            }
            return res;
        }
    }
}
