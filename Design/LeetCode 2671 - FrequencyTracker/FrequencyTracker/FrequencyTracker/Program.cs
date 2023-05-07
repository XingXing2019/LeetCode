using System;
using System.Collections.Generic;

namespace FrequencyTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tracker = new FrequencyTracker();
            tracker.Add(6);
            tracker.Add(2);
            tracker.Add(6);
            tracker.DeleteOne(6);
            tracker.DeleteOne(6);
            tracker.Add(2);
            Console.WriteLine(tracker.HasFrequency(1));
        }
    }

    public class FrequencyTracker
    {
        private Dictionary<int, int> frequencies;
        private Dictionary<int, int> dict;
        public FrequencyTracker()
        {
            frequencies = new Dictionary<int, int>();
            dict = new Dictionary<int, int>();
        }

        public void Add(int number)
        {
            if (!frequencies.ContainsKey(number))
                frequencies[number] = 0;
            var freq = frequencies[number];
            frequencies[number]++;
            if (!dict.ContainsKey(frequencies[number]))
                dict[frequencies[number]] = 0;
            dict[frequencies[number]]++;
            if (freq != 0)
                dict[freq]--;
        }

        public void DeleteOne(int number)
        {
            if (!frequencies.ContainsKey(number) || frequencies[number] == 0)
                return;
            var freq = frequencies[number];
            frequencies[number]--;
            dict[freq]--;
            if (frequencies[number] != 0)
                dict[frequencies[number]]++;
        }

        public bool HasFrequency(int frequency)
        {
            return dict.ContainsKey(frequency) && dict[frequency] != 0;
        }
    }
}
