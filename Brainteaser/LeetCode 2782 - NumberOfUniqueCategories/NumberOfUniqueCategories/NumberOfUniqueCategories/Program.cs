using System;
using System.Collections.Generic;

namespace NumberOfUniqueCategories
{
    internal class Program
    {
        class CategoryHandler
        {
            private readonly int[] _categories;
            public CategoryHandler(int[] categories)
            {
                _categories = categories;
            }

            public bool HaveSameCategory(int a, int b) => a == b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfCategories(int n, CategoryHandler categoryHandler)
        {
            var res = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var found = false;
                foreach (var num in res)
                {
                    if (categoryHandler.HaveSameCategory(i, num))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) 
                    res.Add(i);
            }
            return res.Count;
        }
    }
}
