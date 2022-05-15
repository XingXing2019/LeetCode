using System;

namespace MaximumConsecutiveFloors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxConsecutive(int bottom, int top, int[] special)
        {
            Array.Sort(special);
            var res = 0;
            for (int i = 0; i < special.Length; i++)
            {
                var floors = i == 0 ? special[i] - bottom : special[i] - special[i - 1] - 1;
                res = Math.Max(res, floors);
            }
            return Math.Max(res, top - special[^1]);
        }
    }
}
