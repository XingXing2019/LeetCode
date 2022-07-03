using System;
using System.Collections.Generic;

namespace DecodeTheMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        string DecodeMessage(string key, string message)
        {
            var dict = new Dictionary<char, char>();
            dict[' '] = ' ';
            var letter = 0;
            foreach (var l in key)
            {
                if (dict.ContainsKey(l)) continue;
                dict[l] = (char)(letter + 'a');
                letter++;
            }
            var res = "";
            foreach (var l in message)
                res += dict[l];
            return res;
        }
    }
}
