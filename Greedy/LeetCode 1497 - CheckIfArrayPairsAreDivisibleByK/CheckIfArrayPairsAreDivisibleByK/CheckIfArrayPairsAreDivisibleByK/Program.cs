//让每个数字对k取模，记录模相同数字的个数。如果是负数，就先取相反数在取模。
//检查是不是每个模i和模k-i的和是偶数。
using System;

namespace CheckIfArrayPairsAreDivisibleByK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9 };
            int k = 5;
            Console.WriteLine(CanArrange(arr, k));
        }
        static bool CanArrange(int[] arr, int k)
        {
            var modules = new int[k];
            foreach (var num in arr)
            {
                int number = Math.Abs(num);
                modules[number % k]++;
            }
            for (int i = 0; i <= modules.Length / 2; i++)
            {
                if (i == 0 && modules[i] % 2 != 0 || i != 0 && (modules[i] + modules[k - i]) % 2 != 0)
                    return false;
            }
            return true;
        }
    }
}
