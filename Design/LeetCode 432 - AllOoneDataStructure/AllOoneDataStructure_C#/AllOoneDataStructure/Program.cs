using System;
using System.Collections.Generic;
using System.Linq;

namespace AllOoneDataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new AllOne();
            obj.Inc("a");
            obj.Inc("b");
            obj.Inc("b");
            obj.Inc("c");
            obj.Inc("c");
            obj.Inc("c");
            obj.Dec("b");
            obj.Dec("b");
            obj.Dec("a");
           
            Console.WriteLine(obj.GetMinKey());
        }
    }

    public class AllOne
    {
        class ListNode
        {
            public string Value;
            public ListNode Pre;
            public ListNode Next;

            public ListNode(string value)
            {
                Value = value;
            }
        }

        private Dictionary<ListNode, int> freqs;
        private Dictionary<string, ListNode> nodes;
        private Dictionary<int, ListNode> dict;

        public AllOne()
        {
            freqs = new Dictionary<ListNode, int>();
            nodes = new Dictionary<string, ListNode>();
            dict = new Dictionary<int, ListNode>();
        }

        public void Inc(string key)
        {
            var node = nodes.ContainsKey(key) ? nodes[key] : new ListNode(key);
            if (!nodes.ContainsKey(key))
                nodes[key] = node;
            var freq = freqs.ContainsKey(node) ? freqs[node] : 0;
            if (freq != 0) Remove(node, freq);
            freq++;
            if (dict.ContainsKey(freq))
            {
                dict[freq].Pre = node;
                node.Next = dict[freq];
            }
            dict[freq] = node;
            freqs[node] = freq;
        }

        public void Dec(string key)
        {
            var node = nodes[key];
            var freq = freqs[node];
            Remove(node, freq);
            freq--;
            if (freq == 0)
            {
                freqs.Remove(node);
                nodes.Remove(key);
            }
            else
            {
                if (dict.ContainsKey(freq))
                {
                    dict[freq].Pre = node;
                    node.Next = dict[freq];
                }
                dict[freq] = node;
                freqs[node] = freq;
            }
        }

        public string GetMaxKey()
        {
            if (dict.Count == 0) return "";
            var max = dict.Max(x => x.Key);
            return dict[max].Value;
        }

        public string GetMinKey()
        {
            if (dict.Count == 0) return "";
            var min = dict.Min(x => x.Key);
            return dict[min].Value;
        }

        private void Remove(ListNode node, int freq)
        {
            var pre = node.Pre;
            var next = node.Next;
            if (pre == null && next == null)
                dict.Remove(freq);
            else if (pre != null && next != null)
                pre.Next = next;
            else if (pre == null && next != null)
            {
                next.Pre = null;
                dict[freq] = next;
            }
            else
                pre.Next = null;
            node.Pre = null;
            node.Next = null;
        }
    }
}
