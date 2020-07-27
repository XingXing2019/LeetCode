using System;
using System.Text;

namespace ShuffleString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string RestoreString(string s, int[] indices)
        {
            var res = new char[s.Length];
            for (int i = 0; i < indices.Length; i++)
                res[indices[i]] = s[i];
            return string.Join("", res);
        }
    }
}
