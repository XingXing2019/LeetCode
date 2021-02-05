//创建hIndex记录结果。对citation数组排序，那么对于某篇文章，其后面的文章至少有和其相同的引用次数。所以如果某篇文章的引用次数大于其以及其后面文章个数之和，那么该篇文章与其后面文章个数之和就是h-index。
//遍历数组，如果发现当前文章加上其后文章的个数小于等于当前文章的引用次数，则将hIndex设为当前文章加上其后面文章个数之和，并终止遍历。
using System;

namespace H_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] citation = { 3, 0, 6, 1, 5 };
            Console.WriteLine(HIndex(citation));
        }
        static int HIndex(int[] citations)
        {
            Array.Sort(citations);
            int hIndex = 0;
            for (int i = 0; i < citations.Length; i++)
                if (citations.Length - i <= citations[i])
                {
                    hIndex = citations.Length - i;
                    break;
                }
            return hIndex;
        }
    }
}
