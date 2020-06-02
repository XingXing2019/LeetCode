using System;

namespace AssignCookies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] g = { 1, 2, 3 };
            int[] s = { 3};
            Console.WriteLine(FindContentChildren(g, s));
        }
        static int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int num = 0;
            int j = 0;
            for (int i = 0; i < g.Length; i++)
            {
                for (; j < s.Length; j++)
                {
                    if (g[i] <= s[j])
                    {
                        num++;
                        s[j] = 0;
                        break;
                    }
                }
            }
            return num;
        }
    }
}
