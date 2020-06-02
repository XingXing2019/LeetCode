//牢房的状态是循环的而且算上本身只可能有15种可能。
//创建数组record记录这些可能性，将本身设为数组第一个元素，在循环找出其余14中可能。
//那么N天后，则为数组第N%14个元素。需要注意，如果N能被14整除，则结果为最后一个元素。
using System;

namespace PrisonCellsAfterNDays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cells = { 1, 0, 0, 1, 0, 0, 0, 1 };
            int N = 826;
            Console.WriteLine(PrisonAfterNDays(cells, N));
        }
        static int[] PrisonAfterNDays(int[] cells, int N)
        {          
            int[][] record = new int[15][];
            record[0] = cells;
            for (int i = 1; i < record.Length; i++)
            {
                int[] newCell = new int[8];
                for (int j = 1; j < 7; j++)
                    newCell[j] = cells[j - 1] == cells[j + 1] ? 1 : 0;
                record[i] = newCell;
                cells = newCell;
            }
            int index = N % 14 == 0 ? 14 : N % 14;
            return record[index];
        }
    }
}
