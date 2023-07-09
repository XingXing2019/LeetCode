using System;
using System.Collections.Generic;
using System.Linq;

namespace RelocateMarbles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
        {
            var locations = new HashSet<int>(nums);
            for (int i = 0; i < moveFrom.Length; i++)
            {
                locations.Remove(moveFrom[i]);
                locations.Add(moveTo[i]);
            }
            return locations.OrderBy(x => x).ToArray();
        }
    }
}
