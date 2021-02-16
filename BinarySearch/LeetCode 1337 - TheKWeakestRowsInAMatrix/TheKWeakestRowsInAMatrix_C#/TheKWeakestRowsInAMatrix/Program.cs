//用二分搜索找出每行中士兵的个数，在按照要求操作。
using System;
using System.Collections.Generic;

namespace TheKWeakestRowsInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static int[] KWeakestRows(int[][] mat, int k)
        {
            List<int>[] record = new List<int>[101];
            for (int i = 0; i < mat.Length; i++)
            {
                int num = GetSoldierNum(mat[i]);
                if (record[num] == null)
                    record[num] = new List<int>() { i };
                else
                    record[num].Add(i);
            }          
            int[] res = new int[k];
            int index = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i] != null)
                {
                    for (int j = 0; j < record[i].Count; j++)
                    {
                        res[index++] = record[i][j];
                        if (index >= k)
                            break;
                    }
                }
                if (index >= k)
                    break;
            }
            return res;
        }
        static int GetSoldierNum(int[] row)
        {
            int li = 0, hi = row.Length - 1;
            if (row[li] == 0)
                return 0;
            if (row[hi] == 1)
                return row.Length;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (row[mid] == 0)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
