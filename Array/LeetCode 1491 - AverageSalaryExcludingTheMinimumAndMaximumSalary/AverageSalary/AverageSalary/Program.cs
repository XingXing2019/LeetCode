using System;
using System.Linq;

namespace AverageSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double Average_Sort(int[] salary)
        {
            Array.Sort(salary);
            return ((double)salary.Sum() - salary[0] - salary[^1]) / (salary.Length - 2);
        }
        public double Average_Loop(int[] salary)
        {
            int max = int.MinValue, min = int.MaxValue, sum = 0;
            foreach (var item in salary)
            {
                max = Math.Max(max, item);
                min = Math.Min(min, item);
                sum += item;
            }
            return ((double) sum - max - min) / (salary.Length - 2);
        }
    }
}
