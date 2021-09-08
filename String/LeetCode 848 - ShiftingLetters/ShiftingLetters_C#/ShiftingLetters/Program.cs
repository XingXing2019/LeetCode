//统计每个字母需要变换的次数，然后对、让这个次数对26取模，并存入一个数组。
//遍历S，按照要求将每个字母变换对应次数。
using System;
using System.Text;

namespace ShiftingLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "zdasf";
            int[] shifts = { 52, 87, 455, 45, 9987 };
            Console.WriteLine(ShiftingLetters(S, shifts));
        }
        static string ShiftingLetters(string S, int[] shifts)
        {
            int[] totShifts = new int[S.Length];
            totShifts[totShifts.Length - 1] = shifts[shifts.Length - 1] % 26;
            for (int i = shifts.Length -2; i >=0; i--)
                totShifts[i] = (shifts[i] + totShifts[i + 1]) % 26;
            var s = new StringBuilder(S);
            for (int i = 0; i < totShifts.Length; i++)
            {
                int tem = s[i] + totShifts[i];
                tem = tem > 122 ? tem - 26 : tem;
                s[i] = (char)tem;
            }
            return s.ToString();
        }
    }
}
