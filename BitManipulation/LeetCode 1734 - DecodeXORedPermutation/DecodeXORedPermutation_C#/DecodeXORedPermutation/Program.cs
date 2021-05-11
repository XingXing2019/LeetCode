using System;

namespace DecodeXORedPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] Decode(int[] encoded)
        {
            var res = new int[encoded.Length + 1];
            int first = 0;
            for (int i = 0; i <= encoded.Length + 1; i++)
            {
                first ^= i;
                if (i < encoded.Length + 1 && i % 2 == 1)
                    first ^= encoded[i];
            }
            res[0] = first;
            for (int i = 1; i < res.Length; i++)
                res[i] = res[i - 1] ^ encoded[i - 1];
            return res;
        }
    }
}
