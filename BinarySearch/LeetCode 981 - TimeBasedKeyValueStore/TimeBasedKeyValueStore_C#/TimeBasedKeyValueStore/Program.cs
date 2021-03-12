using System;
using System.Collections.Generic;

namespace TimeBasedKeyValueStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class TimeMap
    {
        private Dictionary<string, List<int>> timeDict;
        private Dictionary<string, List<string>> wordDict;
        public TimeMap()
        {
            timeDict = new Dictionary<string, List<int>>();
            wordDict = new Dictionary<string, List<string>>();
        }
        public void Set(string key, string value, int timestamp)
        {
            if (!timeDict.ContainsKey(key))
            {
                timeDict[key] = new List<int>();
                wordDict[key] = new List<string>();
            }
            timeDict[key].Add(timestamp);
            wordDict[key].Add(value);
        }
        public string Get(string key, int timestamp)
        {
            if (!timeDict.ContainsKey(key)) return "";
            var times = timeDict[key];
            var index = times.BinarySearch(timestamp);
            if (index >= 0) return wordDict[key][index];
            index = -(index + 1);
            if (index == 0) return "";
            return wordDict[key][index - 1];
        }
    }
}
