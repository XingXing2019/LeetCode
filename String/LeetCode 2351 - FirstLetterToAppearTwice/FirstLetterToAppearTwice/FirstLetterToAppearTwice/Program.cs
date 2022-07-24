using System;
using System.Collections.Generic;

namespace FirstLetterToAppearTwice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public char RepeatedCharacter(string s)
        {
            var set = new HashSet<char>();
            foreach (var l in s)
            {
                if (set.Add(l)) continue;
                return l;
            }
            return 'a';
        }
    }
}
