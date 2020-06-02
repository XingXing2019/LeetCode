using System;
using System.Text;

namespace PerformStringShifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abc";
            int[][] shift = new int[2][];
            shift[0] = new int[] {0, 1};
            shift[1] = new int[] {1, 2};
            Console.WriteLine(StringShift(s, shift));
        }
        static string StringShift(string s, int[][] shift)
        {
            var str = new StringBuilder(s);
            foreach (var move in shift)
            {
                move[1] %= s.Length;
                if (move[0] == 0)
                {
                    str.Append(str.ToString().Substring(0, move[1]));
                    str.Remove(0, move[1]);
                }
                else
                {
                    str.Insert(0, str.ToString().Substring(str.Length - move[1]));
                    str.Remove(str.Length - move[1], move[1]);
                }
            }
            return str.ToString();
        }
    }
}
