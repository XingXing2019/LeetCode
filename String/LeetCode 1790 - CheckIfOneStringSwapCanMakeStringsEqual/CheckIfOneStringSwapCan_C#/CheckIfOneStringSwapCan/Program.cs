using System;

namespace CheckIfOneStringSwapCan
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "bank", s2 = "kanb";
            Console.WriteLine(AreAlmostEqual(s1, s2));
        }
        public static bool AreAlmostEqual(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            if (s1 == s2) return true;
            int count = 0, letter1 = 0, letter2 = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    count++;
                    if (count == 1)
                    {
                        letter1 += s1[i];
                        letter2 += s2[i];
                    }
                    else
                    {
                        letter1 -= s2[i];
                        letter2 -= s1[i];
                    }
                }
                if (count > 2) return false;
            }
            return letter1 == 0 && letter2 == 0;
        }
    }
}
