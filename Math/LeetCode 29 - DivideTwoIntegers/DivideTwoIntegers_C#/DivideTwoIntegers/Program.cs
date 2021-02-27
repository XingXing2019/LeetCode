//本题需要用到位运算代替*2操作。思路为不断将divisor乘2，直到divisor超过dividend，记录下在divisor超过dividend之前一共有几个divisor。
//创建递归辅助方法GetLongRes，此方法用long型数据进行运算以免出现溢出。
//将递归边界条件设为当dividend小于divisor时返回0。创建res记录在divisor超过dividend之前一共有几个divisor，初始值设为1。创建tem初始值设为divisor，用tem进行运算防止污染divisor。
//在dividend大于等于tem的条件下循环，使tem左移(相当于乘2)，此时若tem大于dividend，则停止循环。否则res左移(相当于乘2)。
//创建sum记录divisor超过dividend之前的最大值，算法为此时tem右移一位(因为在while循环中tem在最后一次左移后已经超过dividend，左移需要右移一位返回)
//将dividend与sum的差值带入GetLongRes方法递归调用。返回其结果与res的和。这样就能以指数行驶快速接近dividend。
//在主方法中注意特殊处理dividend为int.MinValue，divisor为-1的特殊情况。
//然后调用GetLongRes方法，需注意要将int强制类型转换为long型，以免溢出。最后将结果转换为int型输出，需注意符号判断。
using System;

namespace DivideTwoIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int divident = 10;
            int divisor = 3;
            Console.WriteLine(Divide(divident, divisor));
        }
        static int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;
            long lDivident = Math.Abs((long)dividend);
            long lDivisor = Math.Abs((long)divisor);
            long lRes = GetLongRes(lDivident, lDivisor);
            if ((dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0))
                return (int)lRes;
            else
                return -(int)lRes;
        }
        static long GetLongRes(long dividend, long divisor)
        {
            if (dividend < divisor)
                return 0;
            long res = 1;
            long tem = divisor;
            while (dividend >= tem)
            {
                tem <<= 1;
                if (tem > dividend)
                    break;
                res <<= 1;
            }
            long sum = tem >> 1;
            return res + GetLongRes(dividend - sum, divisor);
        }

        static int Divide_BinarySearch(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            long dividendL = dividend < 0 ? -(long)dividend : (long)dividend;
            long divisorL = divisor < 0 ? -(long)divisor : (long)divisor;
            long li = 1, hi = dividendL;
            while (li < hi)
            {
                long mid = li + (hi - li) / 2;
                if (mid * divisorL > dividendL)
                    hi = mid;
                else
                    li = mid + 1;
            }
            if (divisorL * li > dividendL)
                li--;
            return dividend < 0 && divisor > 0 || dividend > 0 && divisor < 0 ? -(int)li : (int)li;
        }
    }
}
