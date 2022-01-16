using System;
using System.Text;

namespace DivideAStringIntoGroupsOfSizek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string[] DivideString(string s, int k, char fill)
        {
            var len = s.Length % k == 0 ? s.Length / k : s.Length / k + 1;
            var res = new string[len];
            var index = 0;
            for (int i = 0; i < res.Length; i++)
            {
                var temp = new StringBuilder();
                for (int j = 0; j < k; j++)
                {
                    if (index < s.Length)
                        temp.Append(s[index++]);
                    else
                        temp.Append(fill);
                }
                res[i] = temp.ToString();
            }
            return res;
        }
    }
}
