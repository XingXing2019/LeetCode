using System;

namespace NeighboringBitwiseXOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool DoesValidArrayExist(int[] derived)
        {
            return CheckOriginal(derived, 0) || CheckOriginal(derived, 1);
        }

        public bool CheckOriginal(int[] derived, int start)
        {
            var original = new int[derived.Length];
            original[0] = start;
            for (int i = 0; i < original.Length; i++)
            {
                var xor = derived[i] ^ original[i];
                if (i != original.Length - 1)
                    original[i + 1] = xor;
                else
                    original[0] = xor;
            }
            return original[0] == start;
        }
    }
}
