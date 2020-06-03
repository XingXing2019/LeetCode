using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstUniqueNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstUnique = new FirstUnique(new int[] { 2, 3, 5 });
            Console.WriteLine(firstUnique.ShowFirstUnique());
            firstUnique.Add(5);
            Console.WriteLine(firstUnique.ShowFirstUnique());
            firstUnique.Add(2);
            Console.WriteLine(firstUnique.ShowFirstUnique());
            firstUnique.Add(3);
            Console.WriteLine(firstUnique.ShowFirstUnique());
        }
    }
    public class FirstUnique
    {
        private Dictionary<int, int> record;
        public FirstUnique(int[] nums)
        {
            record = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!record.ContainsKey(num))
                    record[num] = 1;
                else
                    record[num]++;
            }
        }

        public int ShowFirstUnique()
        {
            if (record.All(r => r.Value != 1))
                return -1;
            return record.First(r => r.Value == 1).Key;
        }

        public void Add(int value)
        {
            if (!record.ContainsKey(value))
                record[value] = 1;
            else
                record[value]++;
        }
    }
}
