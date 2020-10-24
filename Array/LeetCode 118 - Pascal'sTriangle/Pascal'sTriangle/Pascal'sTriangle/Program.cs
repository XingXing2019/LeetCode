//创建res列表接受结果。循环numRows次，每次在res中加上一个与当前行数等长的数组。
//遍历res数组的每个元素，如果当前元素在三角形的两个边上，则将其设为1。如果当前元素在三角形内部，则将其设为其上一行相邻两个数之和。
using System;
using System.Collections.Generic;

namespace Pascal_sTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows = 5;
            Generate(numRows);
        }
        static IList<IList<int>> Generate(int numRows)
        {
            var res = new int[numRows][];
            if (numRows == 0) return res;
            res[0] = new[] { 1 };
            for (int i = 1; i < numRows; i++)
            {
                res[i] = new int[i + 1];
                for (int j = 0; j < res[i].Length; j++)
                {
                    if (j != 0) res[i][j] += res[i - 1][j - 1];
                    if (j != res[i].Length - 1) res[i][j] += res[i - 1][j];
                }
            }
            return res;
        }
    }
}
