using System;

namespace _1BitAnd2BitCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsOneBitCharacter(int[] bits)
        {
            int index = 0;
            while (index < bits.Length - 1)
            {
                if (bits[index] == 1)
                    index++;
                index++;
            }
            return index == bits.Length - 1;
        }
    }
}
