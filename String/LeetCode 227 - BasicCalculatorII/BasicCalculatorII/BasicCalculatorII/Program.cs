//人为将字符串末尾加上'@'号，作为终止最后一个获取数字的条件。
//遍历字符串，用字符串tem临时存储数字，如果遇到+或者-，则一起存入tem，这样可通过int.Parse得到正确的正负数。
//如果遇到*或者/，则存入符号栈。到下一次得到数字后，再将其弹出，结合符号栈中的*或者/号，进行相应运算。
//将计算的数字都存入，数字栈。最后将数字栈中的数字相加即为结果。
using System;
using System.Collections;

namespace BasicCalculatorII
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "+5*5-14/3*2+1";
            Console.WriteLine(Calculate(s));
        }
        static int Calculate(string s)
        {
            var numbers = s.Split(new[] { ' ', '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            var operators = new Stack<char>();
            var nums = new Stack<int>();
            int index = 0, num = 0;
            s += '@';
            foreach (var letter in s)
            {
                if (char.IsDigit(letter) || letter == ' ') continue;
                num = int.Parse(numbers[index++]);
                if (operators.Count != 0)
                {
                    if (operators.Peek() == '-')
                        num = -num;
                    else if (operators.Peek() == '/')
                        num = nums.Pop() / num;
                    else
                        num = nums.Pop() * num;
                    operators.Pop();
                }
                nums.Push(num);
                if (letter != '+') operators.Push(letter);
            }
            return nums.Sum(x => x);
        }
    }
}
