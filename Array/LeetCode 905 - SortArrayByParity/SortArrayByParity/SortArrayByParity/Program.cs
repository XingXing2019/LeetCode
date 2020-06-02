//创建res接收结果，创建li和hi指针，分别指向数组的头尾。
//遍历A数组，如果是奇数放到hi指针位置，同时hi左移否则放到li指针位置，同时li右移。
using System;

namespace SortArrayByParity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] SortArrayByParity(int[] A)
        {
            int[] res = new int[A.Length];
            int li = 0;
            int hi = A.Length - 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                    res[li++] = A[i];
                else
                    res[hi--] = A[i];
            }
            return res;
        }
    }
}
