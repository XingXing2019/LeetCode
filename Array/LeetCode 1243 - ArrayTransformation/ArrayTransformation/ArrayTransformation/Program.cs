using System;
using System.Collections.Generic;

namespace ArrayTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 6, 3, 4, 3, 5 };
            Console.WriteLine(TransformArray(arr));
        }
        static IList<int> TransformArray(int[] arr)
        {
            bool canChange = true;
            while (canChange)
            {
                canChange = false;
                var temp = new int[arr.Length];
                temp[0] = arr[0];
                temp[^1] = arr[^1];
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
                    {
                        temp[i] = arr[i] - 1;
                        canChange = true;
                    }
                    else if (arr[i] < arr[i - 1] && arr[i] < arr[i + 1])
                    {
                        temp[i] = arr[i] + 1;
                        canChange = true;
                    }
                    else
                        temp[i] = arr[i];
                }
                arr = temp;
            }
            return arr;
        }
    }
}
