//创建car记录进位，初始值设为0。创建cur记录当前为的数字，初始值设为digits最后一个数字与1和car和对10取模。
//将car更新为digits最后一个数字与1和car和对10整除。将digits最后一个数字设为cur。
//从digits倒数第二个数字向前遍历数组。每次遍历将cur更新为当前数字去car之和对10取模。将car更新为当前数字去car之和对10整除。
//再将digits当前数字替换为cur。如果此时digits[i]不为零，证明本次计算没有进位，则可以停止遍历。
//遍历结束后如果car不0，证明最后一次遍历时有进位，则需要重新创建一个比digits长一位的数组res，将其第一个元素设为当前的car之后，将现有digits中所有数字按循序拷贝进res，并返回res。
//如果car为0，则返回现在修改好的digits。
using System;

namespace PlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = {9, 9, 9};
            Console.WriteLine(PlusOne(digits));
        }
        static int[] PlusOne(int[] digits)
        {
            int car = 0;
            digits[digits.Length - 1] += 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var cur = (digits[i] + car) % 10;
                car = (digits[i] + car) / 10;
                digits[i] = cur;
                if(car == 0)
                    break;
            }
            if (car != 0)
            {
                var res = new int[digits.Length + 1];
                res[0] = 1;
                Array.Copy(digits, 0, res, 1, digits.Length);
                return res;
            }
            return digits;
        }
    }
}
