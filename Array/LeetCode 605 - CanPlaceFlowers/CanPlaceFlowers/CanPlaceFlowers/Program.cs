//创建p指针用于遍历flowerbed。在p未到达最后一个元素的条件下遍历，因为要判断p下一个元素。
//当p指向元素为1时，则p跳两格。当p指向元素为0时，如果p下一个元素为1，则p跳3格。否则n减一，p跳两格。
//遍历结束后如果p指向最后一个元素，并且该元素为0，则n减一。
//最后返回n是否小于等于0.
using System;

namespace CanPlaceFlowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] flowerbed = { 1, 0 };
            int n = 1;
            Console.WriteLine(CanPlaceFlowers(flowerbed, n));
        }
        static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int p = 0;
            while (p < flowerbed.Length - 1)
            {
                if (flowerbed[p] == 1)
                    p += 2;
                else
                {
                    if (flowerbed[p + 1] == 1)
                        p += 3;
                    else
                    {
                        n--;
                        p += 2;
                    }
                }
            }
            if (p == flowerbed.Length - 1 && flowerbed[flowerbed.Length - 1] == 0)
                n--;
            return n <= 0;
        }
        public bool CanPlaceFlowers2(int[] flowerbed, int n)
        {
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    n--;
                    flowerbed[i] = 1;
                }
            }
            return n <= 0;
        }
    }
}
