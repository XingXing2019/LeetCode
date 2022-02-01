using System;

namespace FindSubstringWithGivenHashValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "fbxd";
            int power = 31, module = 100, k = 3, hashValue = 32;
            Console.WriteLine(SubStrHash(s, power, module, k, hashValue));
        }
        public static string SubStrHash(string s, int power, int modulo, int k, int hashValue)
        {
            long cur = 0, pk = 1;
            int res = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                cur = (cur * power + s[i] - 'a' + 1) % modulo;
                if (i + k >= s.Length)
                    pk = pk * power % modulo;
                else
                    cur = (cur - (s[i + k] - 'a' + 1) * pk % modulo + modulo) % modulo;
                if (cur == hashValue)
                    res = i;
            }
            return s.Substring(res, k);
        }
    }
}
