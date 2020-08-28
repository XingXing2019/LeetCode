using System;

namespace ImplementRand10UsingRand7
{
    
    class Program
    {
        public int Rand7()
        {
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int Rand10()
        {
            return Ran40() % 10 + 1;
        }

        private int Rand49()
        {
            return (Rand7() - 1) * 7 + (Rand7() - 1);
        }

        private int Ran40()
        {
            int r = Rand49();
            while (r >= 40)
                r = Rand49();
            return r;
        }
    }
}
