using System;

namespace TotalDistanceTraveled
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mainTank = 9, addtionalTank = 2;
            Console.WriteLine(DistanceTraveled(mainTank, addtionalTank));
        }

        public static int DistanceTraveled(int mainTank, int additionalTank)
        {
            var res = 0;
            while (mainTank >= 5 && additionalTank > 0)
            {
                res += 50;
                mainTank -= 5;
                mainTank++;
                additionalTank--;
            }
            return res + mainTank * 10;
        }
    }
}
