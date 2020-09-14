using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace OneEditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "teacher", t = "detacher";
            Console.WriteLine(IsOneEditDistance(s, t));
        }
        static bool IsOneEditDistance(string s, string t)
        {
            if (Math.Abs(s.Length - t.Length) > 1) return false;
            if (s.Length == t.Length)
            {
                if (s == t) return false;
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != t[i])
                        count++;
                    if (count > 1)
                        return false;
                }
                return count == 1;
            }
            if (s.Length > t.Length)
                return ValidateString(s, t);
            return ValidateString(t, s);
        }
        static bool ValidateString(string s, string t)
        {
            for (int i = 0; i < s.Length; i++)
            {
                string temp = s.Substring(0, i - 0);
                temp += i == s.Length - 1 ? "" : s.Substring(i + 1, s.Length - i - 1);
                if (t == temp)
                    return true;
            }
            return false;
        }

    }
}
