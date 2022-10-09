using System;

namespace FindTheOriginalArrayOfPrefixXor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] FindArray(int[] pref)
        {
            var res = new int[pref.Length];
            res[0] = pref[0];
            for (int i = 1; i < pref.Length; i++)
                res[i] = pref[i - 1] ^ pref[i];
            return res;
        }
    }
}
