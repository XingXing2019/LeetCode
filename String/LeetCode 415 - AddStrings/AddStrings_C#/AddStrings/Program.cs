//使用栈反向存储字符串型数字。
//利用current表示当前相加数字之和的各位，carry表示是否有进位。
//通过弹栈反复计算直到其中一个栈为空，如果此时两栈都为空，并且carry为1，则将carry接到res首。
//否则继续将不为空的栈继续弹栈计算current和carry。如果最后carry为1，则将carry接到res首。
using System;
using System.Collections;

namespace AddStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = "9";
            string num2 = "1";
            Console.WriteLine(AddStrings(num1, num2));
        }
        static string AddStrings(string num1, string num2)
        {
            Stack num1Stack = new Stack();
            Stack num2Stack = new Stack();
            for (int i = 0; i < num1.Length; i++)
                num1Stack.Push(num1[i]);
            for (int i = 0; i < num2.Length; i++)
                num2Stack.Push(num2[i]);
            int cur = 0;
            int car = 0;
            string res = "";
            while (num1Stack.Count != 0 && num2Stack.Count != 0)
            {
                cur = (int.Parse(num1Stack.Peek().ToString()) + int.Parse(num2Stack.Peek().ToString()) + car) % 10;
                car = (int.Parse(num1Stack.Pop().ToString()) + int.Parse(num2Stack.Pop().ToString()) + car) / 10;
                res = cur + res;
            }
            if (num1Stack.Count == 0 && num2Stack.Count == 0 && car == 1)
                res = car + res;
            else
            {
                while (num1Stack.Count != 0)
                {
                    cur = (int.Parse(num1Stack.Peek().ToString()) + car) % 10;
                    car = (int.Parse(num1Stack.Pop().ToString()) + car) / 10;
                    res = cur + res;
                }
                while (num2Stack.Count != 0)
                {
                    cur = (int.Parse(num2Stack.Peek().ToString()) + car) % 10;
                    car = (int.Parse(num2Stack.Pop().ToString()) + car) / 10;
                    res = cur + res;
                }
                if (car == 1)
                    res = car + res;
            }
            return res;
        }
    }
}
