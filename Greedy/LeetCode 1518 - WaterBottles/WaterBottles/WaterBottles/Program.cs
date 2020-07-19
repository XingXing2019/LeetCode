using System;

namespace WaterBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBottles = 2, numExchange = 3;
            Console.WriteLine(NumWaterBottles(numBottles, numExchange));
        }
        static int NumWaterBottles(int numBottles, int numExchange)
        {
            int max = numBottles;
            while (numBottles >= numExchange)
            {
                max += numBottles / numExchange;
                numBottles = numBottles / numExchange + numBottles % numExchange;  
            }
            return max;
        }
    }
}
