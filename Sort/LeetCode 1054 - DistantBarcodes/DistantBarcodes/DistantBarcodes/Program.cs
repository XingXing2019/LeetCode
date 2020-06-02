using System;
using System.Collections.Generic;
using System.Linq;

namespace DistantBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] barcodes = { 7, 7, 7, 8, 5, 7, 5, 5, 5, 8 };
            Console.WriteLine(RearrangeBarcodes(barcodes));
        }
        static int[] RearrangeBarcodes(int[] barcodes)
        {
            var dict = new Dictionary<int, int>();
            foreach (var barcode in barcodes)
            {
                if (!dict.ContainsKey(barcode))
                    dict[barcode] = 1;
                else
                    dict[barcode]++;
            }
            var max = dict.Max(d => d.Value);
            var maxBarcode = dict.First(d => d.Value.Equals(max)).Key;
            List<List<int>> lists = new List<List<int>>();
            for (int i = 0; i < max; i++)
            {
                var list = new List<int> { maxBarcode};
                lists.Add(list);
            }
            dict.Remove(maxBarcode);
            int index = 0;
            foreach (var kv in dict)
            {
                int count = kv.Value;
                while (count != 0)
                {
                    lists[index++].Add(kv.Key);
                    count--;
                    index = index > lists.Count - 1 ? 0 : index;
                }
            }
            index = 0;
            var res = new int[barcodes.Length];
            foreach (var list in lists)
                foreach (var barcode in list)
                    res[index++] = barcode;
            return res;
        }
    }
}
