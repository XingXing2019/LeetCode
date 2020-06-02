//尝试以每一个数字作为1的起点，则所需转换的次数为其左边1的个数加上右边0的个数，需要注意如果当前数字为0，那么以他为1的起点时，需要额外多转换一次。
//创建leftOne和rightZero数组用于记录每个数字其左边1的个数和右边0的个数。分别正向和逆向遍历S，将数据记录入两个数组。
//创建minFlip记录结果。遍历S，创建tem记录左边1和右边0之和，如果当前数字为0，则需领tem加一。如果tem小于minFlip，则更新minFlip。
using System;

namespace FlipStringToMonotoneIncreasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "0101100011";
            Console.WriteLine(MinFlipsMonoIncr(S));
        }
        static int MinFlipsMonoIncr(string S)
        {
            int[] leftOne = new int[S.Length];
            int[] rightZero = new int[S.Length];
            int one = 0, zero = 0;
            for (int i = 0; i < S.Length; i++)
            {
                leftOne[i] = one;
                if (S[i] == '1')
                    one++;
            }
            for (int i = S.Length-1; i >= 0; i--)
            {
                rightZero[i] = zero;
                if (S[i] == '0')
                    zero++;
            }
            int minFlip = int.MaxValue;
            for (int i = 0; i < S.Length; i++)
            {
                int tem = leftOne[i] + rightZero[i];
                if (S[i] == 0)
                    tem++;
                minFlip = Math.Min(minFlip, tem);
            }
            return minFlip;
        }
    }
}
