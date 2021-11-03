using System;

namespace CheckIfBinaryString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CheckOnesSegment(string s)
        {
            bool seenZero = false;
            foreach (var l in s)
            {
                if (l == '0') seenZero = true;
                else if (seenZero) return false;
            }
            return true;
        }

        public bool CheckOnesSegment_OneLine(string s)
        {
            return !s.Contains("01");
        }
    }
}
