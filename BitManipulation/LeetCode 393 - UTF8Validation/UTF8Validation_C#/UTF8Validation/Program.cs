using System;

namespace UTF8Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 250, 145, 145, 145, 145 };
            Console.WriteLine(ValidUtf8(data));
        }

        public static bool ValidUtf8(int[] data)
        {
            var index = 0;
            while (index < data.Length)
            {
                int mask = 255, num = data[index], count = 8;
                while (mask != num)
                {
                    count--;
                    mask >>= 1;
                    num >>= 1;
                }
                if (num == 1 || count > 4) return false;
                index++;
                for (int i = 0; i < count - 1; i++)
                {
                    if (index == data.Length || data[index] >> 6 != 2)
                        return false;
                    index++;
                }
            }
            return true;
        }
    }
}
