//创建pre数组，代表当前rowIndex上一行的数组。初始值设为{ 1 }，代表第0行。
//从第一行开始遍历到rowIndex + 1行(多遍历一行，返回pre即为所需结果)，创建长度为当前行数加一的数组cur。
//遍历cur中的每个数字，如果为第一个或最后一个，则将其设为1。否则将去设为pre中的前两个数字之和。遍历结束后将用当前cur替换pre。
//最后返回pre即为结果。
using System;
using System.Collections.Generic;

namespace Pascal_sTriangleII
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowIndex = 3;
            Console.WriteLine(GetRow(rowIndex));
        }
        static IList<int> GetRow(int rowIndex)
        {
            int[] pre = { 1 };
            for (int r = 1; r <= rowIndex; r++)
            {
                int[] cur = new int[r + 1];
                for (int j = 0; j < cur.Length; j++)
                {
                    if (j == 0 || j == r)
                        cur[j] = 1;
                    else
                        cur[j] = pre[j - 1] + pre[j];
                }
                pre = cur;
            }
            return pre;
        }
    }
}
