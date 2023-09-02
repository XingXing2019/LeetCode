using System;
using System.Text;

namespace CheckIfStringsCanBeMadeEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CanBeEqual(string s1, string s2)
        {
            var str1 = new StringBuilder(s1);
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == s2[i]) continue;
                if (i + 2 >= s2.Length || str1[i] != s2[i + 2] || str1[i + 2] != s2[i])
                    return false;
                var temp = str1[i];
                str1[i] = s2[i];
                str1[i + 2] = temp;
            }
            return true;
        }
    }
}
