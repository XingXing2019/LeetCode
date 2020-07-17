using System;
using System.Linq;

namespace RemoveVowelsFromAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string RemoveVowels_Linq(string S)
        {
            var letters = S.Where(x => x != 'a' && x != 'e' && x != 'i' && x != 'o' && x != 'u').ToArray();
            return string.Join("", letters);
        }
        public string RemoveVowels(string S)
        {
            var res = "";
            foreach (var letter in S)
            {
                if (letter != 'a' && letter != 'e' && letter != 'i' && letter != 'o' && letter != 'u')
                    res += letter;
            }
            return res;
        }
    }
}
