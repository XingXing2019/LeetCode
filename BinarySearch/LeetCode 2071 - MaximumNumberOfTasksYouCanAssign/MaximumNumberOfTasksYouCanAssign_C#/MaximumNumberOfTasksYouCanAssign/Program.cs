
using System;
using System.Linq;

namespace MaximumNumberOfTasksYouCanAssign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = { 5, 4 }, workers = { 0, 3, 3 };
            int pills = 1, strength = 1;
            Console.WriteLine(MaxTaskAssign(tasks, workers, pills, strength));
        }

        public static int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
        {
            Array.Sort(tasks);
            Array.Sort(workers);
            int li = 0, hi = tasks.Length;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (!Check(tasks, workers, mid, pills, strength))
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }

        public static bool Check(int[] tasks, int[] workers, int k, int pills, int strength)
        {
            if (workers.Length < k) return false;
            var selectedTasks = tasks[..k].ToList();
            var selectedWorkers = workers[^k..].ToList();
            for (int i = selectedTasks.Count - 1; i >= 0; i--)
            {
                if (selectedWorkers[^1] >= selectedTasks[i])
                    selectedWorkers.RemoveAt(selectedWorkers.Count - 1);
                else
                {
                    if (pills == 0) return false;
                    var index = selectedWorkers.BinarySearch(selectedTasks[i] - strength);
                    if (index < 0) index = ~index;
                    if (index >= selectedWorkers.Count) return false;
                    selectedWorkers.RemoveAt(index);
                    pills--;
                }
            }
            return true;
        }
    }
}
