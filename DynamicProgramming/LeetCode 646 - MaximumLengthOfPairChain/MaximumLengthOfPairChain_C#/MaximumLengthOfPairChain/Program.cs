//先对数据按第一个数字排序。使用Linq语句更为简单。
//创建数组maxLen记录以某个数组结尾能达到的最大长度，创建数组lastNum记录该位置的末位数字。
//将maxLen第一个元素设为1，lastNum第一个元素设为第一个数组的最后一个元素。
//从第二个位置开始遍历。每次试图向前找到一个位置，该位置的lastNum中记录的数字小于当前数组的第一个数字。
//找到后则maxLen[i]等于该位置的长度加一。每次讲当前数组的第二个数字记录入lastNum。
//最后返回maxLen的最后一位。
using System;
using System.Linq;

namespace MaximumLengthOfPairChain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] pairs = new int[6][];
            pairs[0] = new int[2] { 1, 2 };
            pairs[1] = new int[2] { 6, 8 };
            pairs[2] = new int[2] { 6, 7 };
            pairs[3] = new int[2] { 5, 6 };
            pairs[4] = new int[2] { 3, 4 };
            pairs[5] = new int[2] { 7, 9 };
            Console.WriteLine(FindLongestChain(pairs));
        }
        static int FindLongestChain(int[][] pairs)
        {
            var sorted = pairs.OrderBy(r => r[0]).ToArray();
            int[] maxLen = new int[pairs.Length];
            int[] lastNum = new int[pairs.Length];
            maxLen[0] = 1;
            lastNum[0] = sorted[0][1];
            for (int i = 1; i < pairs.Length; i++)
            {
                int pointer = i - 1;
                while (pointer >= 0 && lastNum[pointer] >= sorted[i][0])
                    pointer--;
                if (pointer < 0)
                    maxLen[i] = 1;
                else
                    maxLen[i] = maxLen[pointer] + 1;
                lastNum[i] = sorted[i][1];
            }
            return maxLen[maxLen.Length - 1];
        }
    }
}
