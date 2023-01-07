using System;

namespace CategorizeBoxAccordingToCriteria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string CategorizeBox(int length, int width, int height, int mass)
        {
            int dimensionLimit = 10_000, volLimit = 1_000_000_000, massLimit = 100;
            var isBulk = length >= dimensionLimit || width >= dimensionLimit || height >= dimensionLimit || (long)length * width * height >= volLimit;
            var isHeavy = mass >= massLimit;
            if (isBulk && isHeavy)
                return "Both";
            if (!isBulk && !isHeavy)
                return "Neither";
            return isBulk ? "Bulky" : "Heavy";
        }
    }
}
