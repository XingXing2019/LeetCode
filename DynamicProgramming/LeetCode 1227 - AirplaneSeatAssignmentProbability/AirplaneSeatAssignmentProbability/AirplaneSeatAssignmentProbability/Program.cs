//只要n不是1，那么第n个乘客坐到自己作为的几率都是0.5.
using System;

namespace AirplaneSeatAssignmentProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double NthPersonGetsNthSeat(int n)
        {
            return n == 1 ? 1.00000 : 0.50000;
        }
    }
}
