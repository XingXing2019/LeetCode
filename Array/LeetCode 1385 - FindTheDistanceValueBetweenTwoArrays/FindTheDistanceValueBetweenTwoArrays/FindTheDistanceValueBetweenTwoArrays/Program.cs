using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheDistanceValueBetweenTwoArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 4, 5, 8 };
            int[] arr2 = { 10, 9, 1, 8 };
            int d = 2;
            Console.WriteLine(FindTheDistanceValue(arr1, arr2, d));


        }
        static int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            int res = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (Math.Abs(arr1[i] - arr2[j]) <= d)
                    {
                        res--;
                        break;
                    }
                }
                res++;
            }
            return res;
        }
    }
}
