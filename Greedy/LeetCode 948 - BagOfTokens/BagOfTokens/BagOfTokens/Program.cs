//贪心算法，永远在token小的地方获取分数，在token大的地方获取能量。
//先对数组排序以保证数组首尾分别为最大和最小值，创建left和right指针，分别指向数组的首尾元素。
//创建point记录当前得分，maxPoint记录最大得分。
//如果此时能量P小于数组有元素，证明不能用能量换取得分，则直接返回0。
//在left <= right的条件下遍历数组，如果P大于等于当前left指向的元素，则用能量换取得分，同时left向右移动一位。
//并且如果当前得分point大于最大得分maxPoint，则替换maxPoint。
//如果P小于当前left指向元素，则用得分换取能量，同时right向左移动一位。
//最后返回maxPoint。
using System;

namespace BagOfTokens
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = { 100, 200, 300, 400 };
            int P = 200;
            Console.WriteLine(BagOfTokensScore(tokens, P));
        }
        static int BagOfTokensScore(int[] tokens, int P)
        {
            if (tokens.Length == 0)
                return 0;
            Array.Sort(tokens);
            int left = 0;
            int right = tokens.Length - 1;
            int point = 0;
            int maxPoint = 0;
            if (P < tokens[left])
                return 0;
            while (left <= right)
            {
                if(P >= tokens[left])
                {
                    P -= tokens[left];
                    point++;
                    left++;
                    if (point > maxPoint)
                        maxPoint = point;
                }
                else
                {
                    P += tokens[right];
                    point--;
                    right--;
                }
            }
            return maxPoint;
        }
    }
}
