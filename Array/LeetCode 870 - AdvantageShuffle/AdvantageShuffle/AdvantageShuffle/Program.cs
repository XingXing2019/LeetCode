//相当于田忌赛马。总是试图找到A中比B[i]大的数字中的最小值。
//先将B中的数字保存在一个temB数组中，再将A和B排序。然后利用p1和p2两个指针遍历排序好的数组。如果A中数字大于B中数字，则将B中数字作为key，存入字典，再将A中数字存在对应的列表中。同时双指针各进一。
//如果A中数字不大于B中数字，则将A中数字存入一个tem列表作为劣等马，将来对应B中的上等马。
//遍历temB，如果对应数字在字典中，则取其对应列表的第一个数存入res，并将这个数从列表中删去。如果字典中这个key对应的列表为空时，则将这个key删去。
//如果temB中对应数字不在字典中，则将tem中的第一个数字存入res，并将这个数字删去。
using System;
using System.Collections.Generic;

namespace AdvantageShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 28, 47, 45, 8, 2, 10, 25, 35, 43, 37, 33, 30, 33, 20, 33, 42, 43, 36, 34, 3, 16, 23, 15, 10, 19, 42, 13, 47, 0, 21, 36, 38, 0, 5, 3, 28, 4, 20, 14, 5, 19, 22, 29, 17, 3, 16, 35, 0, 26, 0 };
            int[] B = { 44, 10, 27, 4, 27, 40, 46, 40, 45, 0, 41, 2, 44, 50, 36, 30, 37, 4, 44, 4, 12, 13, 35, 20, 19, 25, 38, 42, 43, 14, 2, 4, 5, 38, 4, 38, 0, 35, 12, 32, 38, 33, 3, 1, 19, 46, 23, 13, 24, 41 };
            Console.WriteLine(AdvantageCount(A, B));
        }
        static int[] AdvantageCount(int[] A, int[] B)
        {
            var dict = new Dictionary<int, List<int>>();
            var tem = new List<int>();
            int[] temB = new int[B.Length];
            for (int i = 0; i < B.Length; i++)
                temB[i] = B[i];
            Array.Sort(A);
            Array.Sort(B);
            int p1 = 0, p2 = 0;
            while (p1 < A.Length)
            {
                if(A[p1] > B[p2])
                {
                    if (!dict.ContainsKey(B[p2]))
                        dict[B[p2++]] = new List<int>() { A[p1++] };
                    else
                        dict[B[p2++]].Add(A[p1++]);
                }
                else
                    tem.Add(A[p1++]);
            }
            int[] res = new int[A.Length];
            for (int i = 0; i < temB.Length; i++)
            {
                if (dict.ContainsKey(temB[i]))
                {
                    res[i] = dict[temB[i]][0];
                    dict[temB[i]].RemoveAt(0);
                    if (dict[temB[i]].Count == 0)
                        dict.Remove(temB[i]);
                }
                else
                {
                    res[i] = tem[0];
                    tem.RemoveAt(0);
                }
            }
            return res;            
        }
    }
}
