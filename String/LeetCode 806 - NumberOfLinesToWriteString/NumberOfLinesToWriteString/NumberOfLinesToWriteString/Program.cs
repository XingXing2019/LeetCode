using System;

namespace NumberOfLinesToWriteString
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] widths = { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string S = "bbbcccdddaaa";
            Console.WriteLine(NumberOfLines(widths, S));
        }
        static int[] NumberOfLines(int[] widths, string S)
        {
            int length = 0;
            int line = 1;
            for (int i = 0; i < S.Length; i++)
            {
                int width = widths[S[i] - 'a'];
                if (length + width <= 100)
                    length += width;
                else
                {
                    line++;
                    length = width;
                }
            }
            return new int[] { line, length };
        }
    }
}
