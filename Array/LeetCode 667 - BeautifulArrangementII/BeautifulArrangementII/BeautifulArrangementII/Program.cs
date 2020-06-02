//通过总结规律可以发现当k为奇数时，生成数组为将最大数字及其前面(k-1)/2个数字，倒序插入正序数组的开头(从第二位开始)
//当k为偶数时，生成数组为将从1开始k/2个数字正序插入倒叙数组的末尾(至倒数第二位结束)。
using System;

namespace BeautifulArrangementII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int k = 3;
            Console.WriteLine(ConstructArray(n, k));
        }
        static int[] ConstructArray(int n, int k)
        {
            int[] res = new int[n];
            int li = 1;
            int hi = n;
            int index = 0;
            int hiLimit = 0;
            if (k % 2 != 0)
            {
                if (k == 1)
                    hiLimit = n + 1;
                else
                    hiLimit = n - (k - 1) / 2;
                while (index < n)
                {
                    if (hi > hiLimit)
                    {
                        res[index++] = li++;
                        res[index++] = hi--;
                    }
                    else
                        res[index++] = li++;
                }
            }
            else
            {
                hiLimit = k + 1;
                while (index < n)
                {
                    if (hi >= hiLimit)
                        res[index++] = hi--;
                    else
                    {
                        res[index++] = li++;
                        res[index++] = hi--;
                    }
                }
            }
            return res;
        }

    }
}
