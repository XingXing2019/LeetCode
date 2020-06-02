using System;
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
            var res = "";
            var words = S.Split(" ");
            int count = 1;
            foreach (var word in words)
            {
                var str = new StringBuilder(word);
                if (isVowel(str[0]))
                    str.Append("ma");
                else
                {
                    str.Append(str[0] + "ma");
                    str.Remove(0, 1);
                }
                for (int j = 0; j < count; j++)
                    str.Append("a");
                count++;
                res += str.ToString() + " ";
            }
            return res.Trim();
        }

        static bool isVowel(char c)
        {
            char[] vowels = {'a', 'e', 'i', 'o', 'u'};
            c = char.ToLower(c);
            foreach (var vowel in vowels)
                if (c == vowel)
                    return true;
            return false;
        }
    }
}
