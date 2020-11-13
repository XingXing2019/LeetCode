using System;
using System.Collections.Generic;
using System.Linq;

namespace AddTwoPolynomials
{
    public class PolyNode
    {
        public int coefficient, power;
        public PolyNode next;

        public PolyNode(int x = 0, int y = 0, PolyNode next = null)
        {
            this.coefficient = x;
            this.power = y;
            this.next = next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PolyNode p1 = new PolyNode(1, 1, null), p2 = new PolyNode(1, 0, null);
            Console.WriteLine(AddPoly(p1, p2));
        }
        static PolyNode AddPoly(PolyNode poly1, PolyNode poly2)
        {
            var dict = new Dictionary<int, int>();
            while (poly1 != null)
            {
                dict[poly1.power] = poly1.coefficient;
                poly1 = poly1.next;
            }
            while (poly2 != null)
            {
                if (!dict.ContainsKey(poly2.power))
                    dict[poly2.power] = 0;
                dict[poly2.power] += poly2.coefficient;
                poly2 = poly2.next;
            }
            dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            PolyNode res = null;
            foreach (var kv in dict)
            {
                if (kv.Value == 0) continue;
                res = new PolyNode(kv.Value, kv.Key, res);
            }
            return res;
        }
    }
}
