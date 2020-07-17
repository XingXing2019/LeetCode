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
    }
}
