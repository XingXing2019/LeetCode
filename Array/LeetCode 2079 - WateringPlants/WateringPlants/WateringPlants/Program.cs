
using System;

namespace WateringPlants
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int WateringPlants(int[] plants, int capacity)
        {
            int res = 0, record = capacity;
            for (int i = 0; i < plants.Length; i++)
            {
                if (capacity >= plants[i])
                    res++;
                else
                {
                    capacity = record;
                    res += i * 2 + 1;
                }
                capacity -= plants[i];
            }
            return res;
        }
    }
}
