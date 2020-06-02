//创建两个指针indexA和indexB分别指向a和b的尾字符。创建current记录现有数字，carry记录进位。创建res接收结果。
//在indexA和indexB都大于等于0的条件下从后向前遍历两个字符串，current为遍历到的数字之和加上carry再对2取模。carry为遍历到的数字之和加上carry对2整除。将current存入res。
//如果a的长度大于b，则遍历结束后，仍需继续遍历a获取current并存入res。否则需要遍历b获取current并存入res。
//此轮遍历结束后，如果carry不为0，则还需将carry存入res。
//最后返回res。
using System;

namespace AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "1";
            string b = "111";
            Console.WriteLine(AddBinary(a, b));
        }
        static string AddBinary(string a, string b)
        {
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;
            int current = 0;
            int carry = 0;
            string res = "";
            while (indexA >= 0 && indexB >= 0)
            {
                int numA = a[indexA] - '0';
                int numB = b[indexB] - '0';
                current = (numA + numB + carry) % 2;
                carry = (numA + numB + carry) / 2;
                res = current + res;
                indexA--;
                indexB--;
            }
            if (a.Length > b.Length)
            {
                while (indexA >= 0)
                {
                    int numA = a[indexA] - '0';
                    current = (numA + carry) % 2;
                    carry = (numA + carry) / 2;
                    res = current + res;
                    indexA--;
                }
            }
            else
            {
                while (indexB >= 0)
                {
                    int numB = b[indexB] - '0';
                    current = (numB + carry) % 2;
                    carry = (numB + carry) / 2;
                    res = current + res;
                    indexB--;
                }
            }
            if (carry != 0)
                res = carry + res;
            return res;
        }
    }
}
