using System;
using System.Linq;

namespace SortThePeople
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string[] SortPeople(string[] names, int[] heights)
        {
            var people = new Tuple<string, int>[names.Length];
            for (int i = 0; i < names.Length; i++)
                people[i] = new Tuple<string, int>(names[i], heights[i]);
            return people.OrderByDescending(x => x.Item2).Select(x => x.Item1).ToArray();
        }
    }
}
