//让num1的每一位与num2的每一位相乘，通过current和carry记录每一位上的数和进位。从而获得num1的每一位与num2相乘结果的字符串。记录入一个字符串列表。
//对列表中的字符串补0，使他们长度对齐。
//在通过列表中每一个字符串中的每一位相加最终获得结果。
//需要注意相乘和相加两次后如果carry的数字不为0，要人为将carry添加入计算结果。
using System;
using System.Collections.Generic;

namespace MultiplyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = "9";
            string num2 = "9";
            Console.WriteLine(Multiply2(num1, num2));
        }
        static string Multiply1(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";
            string res = "";
            int eachDigit = 0;
            List<string> stepResults = new List<string>();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int current = 0;
                int carry = 0;
                string tem = "";
                int num1Digit = num1[i] - '0';
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int num2Digit = num2[j] - '0';
                    current = (num1Digit * num2Digit + carry) % 10;
                    eachDigit = current;
                    carry = (num1Digit * num2Digit + carry) / 10;
                    tem += eachDigit;
                }
                if (carry != 0)
                    tem += carry;
                for (int time = 0; time < num1.Length - 1 - i; time++)
                    tem = "0" + tem;
                stepResults.Add(tem);
            }
            int maxLen = 0;
            foreach (var result in stepResults)
                if (result.Length > maxLen)
                    maxLen = result.Length;
            for (int i = 0; i < stepResults.Count; i++)
            {
                for (int j = stepResults[i].Length; j < maxLen; j++)
                    stepResults[i] += "0";
            }
            int resCarry = 0;
            for (int i = 0; i < maxLen; i++)
            {
                int resCurrent = 0;
                int resDigit = 0;
                foreach (var result in stepResults)
                {
                    resDigit += result[i] - '0';
                }
                resCurrent = (resDigit + resCarry) % 10;
                resCarry = (resDigit + resCarry) / 10;
                res = resCurrent + res;
            }
            if (resCarry != 0)
                res = resCarry + res;
            return res;
        }

        static string Multiply2(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";
            var resList = new List<int>();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int digitNum1 = num1[i] - '0';
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int digitNum2 = num2[j] - '0';
                    int temNum = digitNum1 * digitNum2;
                    if ((num1.Length - 1 - i + num2.Length - 1 - j) <= resList.Count)
                        resList.Add(0);
                    resList[num1.Length - 1 - i + num2.Length - 1 - j] += temNum;
                }
            }
            int current = 0;
            int carry = 0;
            string res = "";
            for (int i = 0; i < resList.Count; i++)
            {
                current = (resList[i] + carry) % 10;
                res = current + res;
                carry = (resList[i] + carry) / 10;
            }
            if (carry != 0)
                res = carry + res;
            int start = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != '0')
                {
                    start = i;
                    break;
                }
            }
            return res.Substring(start);
        }
    }
}
