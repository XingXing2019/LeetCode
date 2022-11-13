using System;

namespace ConvertTheTemperature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public double[] ConvertTemperature(double celsius)
        {
            return new[] { celsius + 273.15, celsius * 1.8 + 32 };
        }
    }
}
