using System;

namespace ElementAppearingMoreThan25
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 2, 6, 6, 6, 7, 7, 7 };
            Console.WriteLine(FindSpecialInteger(arr));
        }
        static int FindSpecialInteger(int[] arr)
        {
            int frequency = arr.Length / 4;
            int count = 0;
            int tem = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == tem)
                    count++;
                else
                {
                    tem = arr[i];
                    count = 1;
                }
                if (count > frequency)
                    return arr[i];
            }
            return -1;
        }
    }
}
