using System;

namespace DefuseTheBomb
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] code = {5, 7, 1, 4};
            int k = -3;
            Console.WriteLine(Decrypt(code, k));
        }
        static int[] Decrypt(int[] code, int k)
        {
            var res = new int[code.Length];
            int copy = k > 0 ? k : -k;
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 1; j <= copy; j++)
                {
                    int index = k > 0 ? i + j : i - j;
                    if (index >= code.Length || index < 0)
                        index = k > 0 ? index % code.Length : index + code.Length;
                    res[i] += code[index];
                }
            }
            return res;
        }
    }
}
