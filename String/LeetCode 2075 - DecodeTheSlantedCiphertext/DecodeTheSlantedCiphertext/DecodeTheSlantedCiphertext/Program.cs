using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeTheSlantedCiphertext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encodedText = " b  ac";
            var rows = 2;
            Console.WriteLine(DecodeCiphertext(encodedText, rows));
        }

        public static string DecodeCiphertext(string encodedText, int rows)
        {
            int size = encodedText.Length / rows, index = 0;
            var words = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                words[i] = encodedText.Substring(index, size);
                index += size;
            }
            var res = new StringBuilder();
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < rows && i + j < size; i++)
                    res.Append(words[i][i + j]);
            }
            return res.ToString().TrimEnd();
        }
    }
}
