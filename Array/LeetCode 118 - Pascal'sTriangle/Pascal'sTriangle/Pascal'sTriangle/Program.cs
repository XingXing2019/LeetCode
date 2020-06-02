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
            List<IList<int>> res = new List<IList<int>>();
            for (int r = 0; r < numRows; r++)
                res.Add(new int[r + 1]);
            for (int r = 0; r < numRows; r++)
                for (int c = 0; c <= r; c++)
                {
                    if (c == 0 || c == r)
                        res[r][c] = 1;
                    else
                        res[r][c] = res[r - 1][c - 1] + res[r - 1][c];
                }
            return res;
        }
    }
}
