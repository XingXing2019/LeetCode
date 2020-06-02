//从两个数组最后一位向前逐位相加，记录相加数字和进位。但进位方式与二进制不同。
//当cur大于1时，进位为-1，cur为当前cur减2。当cur为-1时，进位为1，cur为1。其他情况进位为0，cur为当前cur。
//如果两个数组长度不等，则对长的数组余下的位数做同上操作。
//操作结束后，如果car不为0，继续做同上操作直到car为0。最后还要去除前导0.
using System;
using System.Collections.Generic;

namespace AddingTwoNegabinaryNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1 };
            int[] arr2 = { 1, 1, 0, 1 };
            Console.WriteLine(AddNegabinary(arr1, arr2));
        }
        static int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            int cur = 0, car = 0;
            int p1 = arr1.Length - 1, p2 = arr2.Length - 1;
            List<int> temRes = new List<int>();
            while (p1 >= 0 && p2 >= 0)
            {
                cur = arr1[p1--] + arr2[p2--] + car;
                if (cur > 1)
                {
                    temRes.Insert(0, cur - 2);
                    car = -1;
                }
                else if (cur == -1)
                {
                    temRes.Insert(0, 1);
                    car = 1;
                }
                else
                {
                    temRes.Insert(0, cur);
                    car = 0;
                }
            }
            if (arr1.Length > arr2.Length)
            {
                while (p1 >= 0)
                {
                    cur = arr1[p1--] + car;
                    if (cur > 1)
                    {
                        temRes.Insert(0, cur - 2);
                        car = -1;
                    }
                    else if (cur == -1)
                    {
                        temRes.Insert(0, 1);
                        car = 1;
                    }
                    else
                    {
                        temRes.Insert(0, cur);
                        car = 0;
                    }
                }
            }
            else
            {
                while (p2 >= 0)
                {
                    cur = arr2[p2--] + car;
                    if (cur > 1)
                    {
                        temRes.Insert(0, cur - 2);
                        car = -1;
                    }
                    else if (cur == -1)
                    {
                        temRes.Insert(0, 1);
                        car = 1;
                    }
                    else
                    {
                        temRes.Insert(0, cur);
                        car = 0;
                    }
                }
            }
            while (car != 0)
            {
                cur = 0 + car;
                if (cur > 1)
                {
                    temRes.Insert(0, cur - 2);
                    car = -1;
                }
                else if (cur == -1)
                {
                    temRes.Insert(0, 1);
                    car = 1;
                }
                else
                {
                    temRes.Insert(0, cur);
                    car = 0;
                }
            }
            p1 = 0;
            while (p1 < temRes.Count - 1 && temRes[p1] == 0)
                p1++;
            int[] res = new int[temRes.Count - p1];
            for (int i = 0; i < res.Length; i++)
                res[i] = temRes[p1++];
            return res;
        }
    }
}
