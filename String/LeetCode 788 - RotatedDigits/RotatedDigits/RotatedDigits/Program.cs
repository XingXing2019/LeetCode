//创建count记录结果。遍历1到N之间的数字。创建flag1初始值设为true，代表没有遇到3，4，7这些不能转化的数字，如果遇到则将flag1设为false。
//创建flag2初始值设为false，代表没有遇到2，5，6，9这些可以转化的数字，如果遇到，则将flag2设为true。
//对于1到N中的每一个数字，获取每一位上的数字。如果为3，4，7，将flag1设为false，并终止遍历。如果为2，5，6，9，将flag2设为true。
//只有当flag1和flag2都为true的条件下，证明没有遇到3，4，7，但是遇到了2，5，6，9。则使count加一。
using System;

namespace RotatedDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 15;
            Console.WriteLine(RotatedDigits(N));
        }
        static int RotatedDigits(int N)
        {
            int count = 0;
            for (int num = 1; num <= N; num++)
            {
                bool flag1 = true;
                bool flag2 = false;
                int tem = num;
                while (tem != 0)
                {
                    int digit = tem % 10;
                    if (digit == 3 || digit == 4 || digit == 7)
                    {
                        flag1 = false;
                        break;
                    }
                    else if (digit == 2 || digit == 5 || digit == 6 || digit == 9)
                        flag2 = true;
                    tem /= 10;
                }
                if (flag1 && flag2)
                    count++;
            }
            return count;
        }
    }
}
