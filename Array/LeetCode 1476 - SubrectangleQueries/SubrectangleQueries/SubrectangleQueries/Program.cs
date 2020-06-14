//每次更新数组中的数组尾新值。
using System;

namespace SubrectangleQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class SubrectangleQueries
    {
        private int[][] _rectangle;
        public SubrectangleQueries(int[][] rectangle)
        {
            _rectangle = rectangle;
        }

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            for (int r = row1; r <= row2; r++)
                for (int c = col1; c <= col2; c++)
                    _rectangle[r][c] = newValue;
        }

        public int GetValue(int row, int col)
        {
            return _rectangle[row][col];
        }
    }
}
