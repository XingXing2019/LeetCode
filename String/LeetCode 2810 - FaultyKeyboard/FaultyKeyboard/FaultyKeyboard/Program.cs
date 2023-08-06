using System;
using System.Collections.Generic;

namespace FaultyKeyboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string FinalString(string s)
        {
            var letters = new List<char>();
            foreach (var l in s)
            {
                if (l != 'i')
                    letters.Add(l);
                else
                    letters.Reverse();
            }
            return string.Join("", letters);
        }
    }
}
