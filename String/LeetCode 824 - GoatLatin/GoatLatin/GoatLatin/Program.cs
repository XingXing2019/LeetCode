using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoatLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "The quick brown fox jumped over the lazy dog";
            Console.WriteLine(ToGoatLatin(S));
        }
        static string ToGoatLatin(string S)
        {
            var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            var words = S.Split(" ");
            var res = "";
            for (int i = 0; i < words.Length; i++)
            {
                var str = new StringBuilder(words[i]);
                if (vowels.Contains(words[i][0]))
                    str.Append("ma");
                else
                {
                    str.Remove(0, 1);
                    str.Append($"{words[i][0]}ma");
                }
                for (int j = 0; j < i + 1; j++)
                    str.Append('a');
                res += str.ToString();
                if (i != words.Length - 1)
                    res += " ";
            }
            return res;
        }
    }
}
