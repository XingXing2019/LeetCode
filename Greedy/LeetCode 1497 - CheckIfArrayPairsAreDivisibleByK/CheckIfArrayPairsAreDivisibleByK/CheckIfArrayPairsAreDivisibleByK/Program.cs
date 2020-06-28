//让每个数字对k取模，记录模相同数字的个数。如果是负数，就先取相反数在取模。
//检查是不是每个模i和模k-i的和是偶数。
using System;

namespace CheckIfArrayPairsAreDivisibleByK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -4, 1, -2, 2, -3, 3, -4, 4 };
            int k = 3;
            Console.WriteLine(CanArrange(arr, k));
        }
        static bool CanArrange(int[] arr, int k)
        {
            var modules = new int[k];
            foreach (var num in arr)
            {
                if(num >= 0) 
                    modules[num % k]++;
                else
                    modules[-num % k]++;
            }
            if (modules[0] % 2 != 0) 
                return false;
            for (int i = 1; i <= modules.Length / 2; i++)
                if ((modules[i] + modules[k - i]) % 2 != 0) 
                    return false;
            return true;
        }
    }
}
