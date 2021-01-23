using System;
using System.Collections.Generic;
using System.Linq;

namespace ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "AB";
            int numRow = 1;
            Console.WriteLine(Convert(s, numRow));
        }
        static string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            var rows = new List<char>[numRows];
            for (int i = 0; i < rows.Length; i++)
                rows[i] = new List<char>();
            int r = 0;
            var moveDown = true;
            foreach (var letter in s)
            {
                rows[r].Add(letter);
                if (r == 0) moveDown = true;
                else if (r == numRows - 1) moveDown = false;
                r += moveDown ? 1 : -1;
            }
            return rows.Aggregate("", (current, row) => current + string.Join("", row));
        }
    }
}
