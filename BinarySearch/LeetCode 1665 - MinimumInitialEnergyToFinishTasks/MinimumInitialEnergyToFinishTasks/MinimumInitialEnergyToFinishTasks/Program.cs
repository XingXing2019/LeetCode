using System;
using System.Linq;

namespace MinimumInitialEnergyToFinishTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumEffort(int[][] tasks)
        {
            tasks = tasks.OrderByDescending(x => x[1] - x[0]).ToArray();
            int li = 0, hi = tasks.Sum(x => x[1]);
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (CanPass(tasks, mid))
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return li;
        }

        private bool CanPass(int[][] tasks, int mid)
        {
            foreach (var task in tasks)
            {
                if (mid < task[1] || mid < task[0])
                    return false;
                mid -= task[0];
            }
            return true;
        }
    }
}
