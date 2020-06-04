using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ProductOfTheLastKNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new ProductOfNumbers();
            product.Add(3);
            product.Add(0);
            product.Add(2);
            product.Add(5);
            product.Add(4);

            Console.WriteLine(product.GetProduct(2));
            Console.WriteLine(product.GetProduct(3));
            Console.WriteLine(product.GetProduct(4));

            product.Add(8);
            Console.WriteLine(product.GetProduct(2));
        }
    }
    public class ProductOfNumbers
    {
        private List<int> prefix;
        public ProductOfNumbers()
        {
            prefix = new List<int> {1};
        }

        public void Add(int num)
        {
            if (num == 0)
                prefix = new List<int> {1};
            else
                prefix.Add(num * prefix[^1]);
        }

        public int GetProduct(int k)
        {
            if (k >= prefix.Count) return 0;
            return prefix[^1] / prefix[^(k + 1)];
        }
    }
}
