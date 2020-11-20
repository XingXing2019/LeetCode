//思路为先从左向右扫描字符串，如果扫描过的左括号加上*的数量少于扫描过的右括号的数量，证明一定有右括号不能配对。则返回false。
//再从右向左扫描字符串，如果扫描过的右括号加上*的数量少于扫描过的左括号的数量，证明一定有左括号不能被配对，则返回false。
//如果两次扫描都能通过，则返回true。
//创建scannedLOrS计数器，用于记录扫描过的左括号或者星号数量。从左向右扫描字符串，如果当前字符不为右括号，则令scannedLOrS加一，代表扫描到了左括号或者星号。
//否则令scannedLOrS减一，代表消耗了一个左括号或者星号抵消右括号。如果当前scannedLOrS小于0，则返回false。
//创建scannedROrS计数器，用于记录扫描过的右括号或者星号数量。从右向左扫描字符串，如果当前字符不为左括号，则令scannedROrS加一，代表扫描到了右括号或者星号。
//否则令scannedROrS减一，代表消耗了一个右括号或者星号抵消左括号。如果当前scannedROrS小于0，则返回false。
//如果两次扫描都通过了，则返回true。
using System;
using System.Collections;

namespace ValidParenthesisString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "(";
            Console.WriteLine(CheckValidString(s));
        }
        static bool CheckValidString(string s)
        {
            int extraLeftOrStar = 0, extraRightOrStar = 0; 
            for (int i = 0; i < s.Length; i++)
            {
                extraLeftOrStar += s[i] != ')' ? 1 : -1;
                if (extraLeftOrStar < 0) return false;
                extraRightOrStar += s[s.Length - i - 1] != '(' ? 1 : -1;
                if (extraRightOrStar < 0) return false;
            }
            return true;
        }
    }
}
