using System;
using System.Collections.Generic;
using System.Linq;

namespace SenderWithLargestWordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string LargestWordCount(string[] messages, string[] senders)
        {
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < messages.Length; i++)
            {
                if (!dict.ContainsKey(senders[i]))
                    dict[senders[i]] = 0;
                dict[senders[i]] += messages[i].Split(' ').Length;
            }
            var res = "";
            var max = 0;
            foreach (var sender in dict.Keys)
            {
                if (dict[sender] <= max && (dict[sender] != max || Compare(res, sender) >= 0)) continue;
                res = sender;
                max = dict[sender];
            }
            return res;
        }

        public int Compare(string sender1, string sender2)
        {
            if (sender1 == sender2) return 0;
            for (int i = 0; i < Math.Min(sender1.Length, sender2.Length); i++)
            {
                if (sender1[i] < sender2[i])
                    return -1;
                else if (sender1[i] > sender2[i])
                    return 1;
            }
            return sender1.Length < sender2.Length ? -1 : 1;
        }
    }
}
