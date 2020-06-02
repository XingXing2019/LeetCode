//创建count标记应该做加法的位置。初始值设为N-3，之后没做一次加法，令count减4。创建tem记录每个乘除操作后的数字，初始值设为N。
//创建isMultiply记录是做乘法还是除法，创建isFirst记录是否为第一个乘除结果，因为之后的乘除结果要取负数。
//从N-1开始向前遍历。如果i等于count，则应将当前数字加入res，并令count减4。再根据是否是第一个乘除结果决定将tem如何记录入res。之后令tem等于i-1，同时令i减一。
//如果i不等于count，则根据isMultiply决定如何将i记录入tem。同时要调转isMultiply。
//最后返回tem和res-tem中较大的值。
using System;

namespace ClumsyFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 2;
            Console.WriteLine(Clumsy(N));
        }
        static int Clumsy(int N)
        {
            int count = N - 3;
            int res = 0;
            int tem = N;
            bool isMultiply = true;
            bool isFirst = true;
            for (int i = N - 1; i > 0; i--)
            {
                if(i == count)
                {
                    res += i;
                    count -= 4;
                    if (isFirst)
                    {
                        res += tem;
                        isFirst = false;
                    }
                    else
                        res -= tem;
                    tem = --i;
                }
                else
                {
                    if (isMultiply)
                    {
                        tem *= i;
                        isMultiply = false;
                    }
                    else
                    {
                        tem /= i;
                        isMultiply = true;
                    }
                }
            }
            return Math.Max(res - tem, tem);
        }
    }
}
