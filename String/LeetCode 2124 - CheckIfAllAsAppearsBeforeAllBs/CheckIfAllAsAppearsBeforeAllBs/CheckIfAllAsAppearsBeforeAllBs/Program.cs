using System;

namespace CheckIfAllAsAppearsBeforeAllBs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CheckString(string s)
        {
            return s.IndexOf('b') == -1 || s.IndexOf('b') > s.LastIndexOf('a');
        }
    }
}
