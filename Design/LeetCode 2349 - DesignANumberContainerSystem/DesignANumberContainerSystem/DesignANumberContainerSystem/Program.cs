using System;
using System.Collections.Generic;

namespace DesignANumberContainerSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new NumberContainers();
            Console.WriteLine(container.Find(10));
            container.Change(2, 10);
            container.Change(1, 10);
            container.Change(3, 10);
            container.Change(5, 10);
            Console.WriteLine(container.Find(20));
            container.Change(1, 20);
            Console.WriteLine(container.Find(10));
        }
    }

    public class NumberContainers
    {
        private Dictionary<int, int> indexDict;
        private Dictionary<int, SortedSet<int>> numDict;
        public NumberContainers()
        {
            numDict = new Dictionary<int, SortedSet<int>>();
            indexDict = new Dictionary<int, int>();
        }

        public void Change(int index, int number)
        {
            if (indexDict.ContainsKey(index))
            {
                var num = indexDict[index];
                numDict[num].Remove(index);
            }
            indexDict[index] = number;
            if (!numDict.ContainsKey(number))
                numDict[number] = new SortedSet<int>();
            numDict[number].Add(index);
        }

        public int Find(int number)
        {
            if(!numDict.ContainsKey(number) || numDict[number].Count == 0)
                return -1;
            return numDict[number].Min;
        }
    }
}
