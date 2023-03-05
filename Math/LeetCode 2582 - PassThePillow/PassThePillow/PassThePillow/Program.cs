using System;

namespace PassThePillow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PassThePillow(int n, int time)
        {
            time %= 2 * (n - 1);
            return time > n - 1 ? n - time % (n - 1) : time + 1;
        }
    }
}
