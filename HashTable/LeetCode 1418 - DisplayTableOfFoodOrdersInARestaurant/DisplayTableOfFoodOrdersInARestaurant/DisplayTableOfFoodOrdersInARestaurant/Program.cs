using System;
using System.Collections.Generic;
using System.Linq;

namespace DisplayTableOfFoodOrdersInARestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        {
            var record = new Dictionary<string, Dictionary<string, int>>();
            var dishes = new HashSet<string>();
            foreach (var order in orders)
            {
                if (!dishes.Contains(order[2]))
                    dishes.Add(order[2]);
                if (!record.ContainsKey(order[1]))
                    record[order[1]] = new Dictionary<string, int> {{order[2], 1}};
                else
                {
                    if (record[order[1]].ContainsKey(order[2]))
                        record[order[1]][order[2]]++;
                    else
                        record[order[1]][order[2]] = 1;
                }
            }
            var orderedDishes = dishes.ToList();
            orderedDishes.Sort(StringComparer.Ordinal);
            var res = new List<IList<string>>();
            foreach (var kv in record)
            {
                var tem = new List<string> {kv.Key};
                foreach (var dish in orderedDishes)
                {
                    if(kv.Value.ContainsKey(dish))
                        tem.Add(kv.Value[dish].ToString());
                    else
                        tem.Add("0");
                }
                res.Add(tem);
            }
            res = res.OrderBy(r => int.Parse(r[0])).ToList();
            orderedDishes.Insert(0, "Table");
            res.Insert(0, orderedDishes);
            return res;
        }
    }
}
