using System;
using System.Text;

namespace ShiftingLettersII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "abc";
            var shifts = new int[][]
            {
                new int[] {0, 1, 0},
                //new int[] {1, 2, 1},
                //new int[] {0, 2, 1 },
            };
            Console.WriteLine(ShiftingLetters(s, shifts));
        }

        public static string ShiftingLetters(string s, int[][] shifts)
        {
            var moves = new int[s.Length + 1];
            foreach (var shift in shifts)
            {
                moves[shift[0]] += shift[2] == 0 ? -1 : 1;
                moves[shift[1] + 1] += shift[2] == 1 ? -1 : 1;
            }
            var res = new StringBuilder();
            var move = 0;
            for (int i = 0; i < s.Length; i++)
            {
                move += moves[i];
                var letter = s[i] + move % 26;
                if (letter < 'a')
                    letter = 'z' - ('a' - letter) + 1;
                else if (letter > 'z')
                    letter = letter - 'z' + 'a' - 1;
                res.Append((char)(letter));
            }
            return res.ToString();
        }
    }
}
