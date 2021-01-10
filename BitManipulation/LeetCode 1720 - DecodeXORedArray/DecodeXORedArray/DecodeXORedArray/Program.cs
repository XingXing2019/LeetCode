using System;

namespace DecodeXORedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] Decode(int[] encoded, int first)
        {
            var res = new int[encoded.Length + 1];
            res[0] = first;
            for (int i = 0; i < encoded.Length; i++)
                res[i + 1] = encoded[i] ^ res[i];
            return res;
        }
    }
}
