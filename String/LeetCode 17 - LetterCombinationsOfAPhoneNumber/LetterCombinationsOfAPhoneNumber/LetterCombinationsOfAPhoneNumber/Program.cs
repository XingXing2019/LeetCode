//创建辅助方法CombineDigitWithArray用于将数字代表的字母，与已生成的字符列表中的每个元素配对。
//创建n1将char型数字转换为int型。创建strNum1代表当前数字代表的字母串。创建字符串列表res用于接收结果。
//遍历strNum1和res，将strNum1中的字母和字符串中的已生成字符串一一配对，并记录如res。最后返回res。
//在主方法中创建result用于记录结果。如果传入digit为空，则直接返回result。
//创建firstStr代表第一个数字所代表的的字符串。遍历firstStr将每个字母传入result。
//从digit第二个元素开始遍历，调用CombineDigitWithArray将所遍历到的数字所代表的字母与当前result一一配对，并将返回结果赋予result。
//最后返回result。
using System;
using System.Collections.Generic;

namespace LetterCombinationsOfAPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string digit = "23";
            Console.WriteLine(LetterCombinations(digit));
        }
        static IList<string> LetterCombinations(string digits)
        {
            string[] numLetter = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<string> result = new List<string>();
            if (digits == "")
                return result;
            string firstStr = numLetter[digits[0] - '0'];
            for (int i = 0; i < firstStr.Length; i++)
            {
                result.Add(firstStr[i].ToString());
            }
            for (int i = 1; i < digits.Length; i++)
            {
                result = CombineDigitWithArray(digits[i], result);
            }
            return result;
        }

        static List<string> CombineDigitWithArray(char num1, List<string> letters)
        {
            string[] numLetter = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            int n1 = num1 - '0';
            string strNum1 = numLetter[n1];
            List<string> res = new List<string>();
            for (int i = 0; i < strNum1.Length; i++)
            {
                for (int j = 0; j < letters.Count; j++)
                {
                    string tem = letters[j] + strNum1[i];
                    res.Add(tem);
                }
            }
            return res;
        }
    }
}
