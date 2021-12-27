using System;

namespace ExecutionOfAllSuffixInstructions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] ExecuteInstructions(int n, int[] startPos, string s)
        {
            var res = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                res[i] = Move(n, startPos[0], startPos[1], s.Substring(i));
            }
            return res;
        }

        public int Move(int n, int x, int y, string instructions)
        {
            var res = 0;
            foreach (var instruction in instructions)
            {
                if (instruction == 'U')
                    x--;
                else if (instruction == 'D')
                    x++;
                else if (instruction == 'L')
                    y--;
                else
                    y++;
                if (x < 0 || x >= n || y < 0 || y >= n)
                    return res;
                res++;
            }
            return res;
        }
    }
}
