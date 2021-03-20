using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignUndergroundSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class UndergroundSystem
    {
        private Dictionary<int, Tuple<string, double>> person;
        private Dictionary<string, double> tripTime;
        private Dictionary<string, double> tripCount;
        public UndergroundSystem()
        {
            person = new Dictionary<int, Tuple<string, double>>();
            tripTime = new Dictionary<string, double>();
            tripCount = new Dictionary<string, double>();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            person[id] = new Tuple<string, double>(stationName, t);
        }

        public void CheckOut(int id, string stationName, int t)
        {
            if (!tripTime.ContainsKey($"{person[id].Item1}:{stationName}"))
            {
                tripTime[$"{person[id].Item1}:{stationName}"] = 0;
                tripCount[$"{person[id].Item1}:{stationName}"] = 0;
            }
            tripTime[$"{person[id].Item1}:{stationName}"] += t - person[id].Item2;
            tripCount[$"{person[id].Item1}:{stationName}"]++;
            person.Remove(id);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            return tripTime[$"{startStation}:{endStation}"] / tripCount[$"{startStation}:{endStation}"];
        }
    }
}
