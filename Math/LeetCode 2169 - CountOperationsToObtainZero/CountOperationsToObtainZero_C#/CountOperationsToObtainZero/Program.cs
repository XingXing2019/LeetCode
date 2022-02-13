using System;

namespace CountOperationsToObtainZero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountOperations(int num1, int num2)
        {
            var res = 0;
            while (num1 != 0 && num2 != 0)
            {
                if (num1 >= num2)
                    num1 -= num2;
                else
                    num2 -= num1;
                res++;
            }
            return res;
        }
    }
}
