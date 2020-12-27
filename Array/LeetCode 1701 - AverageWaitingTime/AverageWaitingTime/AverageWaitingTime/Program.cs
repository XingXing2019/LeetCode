using System;

namespace AverageWaitingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double AverageWaitingTime(int[][] customers)
        {
            var curTime = customers[0][0];
            double wait = 0;
            foreach (var customer in customers)
            {
                if (curTime - customer[0] < 0)
                    curTime = customer[0];
                wait += curTime - customer[0] + customer[1];
                curTime += customer[1];
            }
            return wait / customers.Length;
        }
    }
}
