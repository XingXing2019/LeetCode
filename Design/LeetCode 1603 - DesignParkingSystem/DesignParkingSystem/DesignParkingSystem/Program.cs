using System;
using System.Collections.Generic;

namespace DesignParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class ParkingSystem
    {
        private Dictionary<int, int> dict;
        public ParkingSystem(int big, int medium, int small)
        {
            dict = new Dictionary<int, int>{{1, big}, {2, medium}, {3, small}};
        }

        public bool AddCar(int carType)
        {
            dict[carType]--;
            return dict[carType] >= 0;
        }
    }

}
