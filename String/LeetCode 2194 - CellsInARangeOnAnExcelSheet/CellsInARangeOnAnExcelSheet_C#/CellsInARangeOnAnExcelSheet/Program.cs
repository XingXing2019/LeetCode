using System;
using System.Collections.Generic;

namespace CellsInARangeOnAnExcelSheet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<string> CellsInRange(string s)
        {
            var cells = s.Split(':');
            char col1 = cells[0][0], col2 = cells[1][0];
            int row1 = cells[0][1] - '0', row2 = cells[1][1] - '0';
            var res = new List<string>();
            for (int i = col1; i <= col2; i++)
            {
                for (int j = row1; j <= row2; j++)
                {
                    res.Add($"{(char)col1}{j}");
                }
                col1++;
            }
            return res;
        }
    }
}
