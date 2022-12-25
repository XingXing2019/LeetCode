using System;

namespace MaximumEnemyForts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CaptureForts(int[] forts)
        {
            int mark = 0, count = 0, res = 0;
            foreach (var fort in forts)
            {
                if (fort == 1)
                {
                    if (mark == -1)
                        res = Math.Max(res, count);
                    mark = 1;
                    count = 0;
                }
                else if (fort == -1)
                {
                    if (mark == 1)
                        res = Math.Max(res, count);
                    mark = -1;
                    count = 0;
                }
                else if (mark != 0)
                    count++;
            }
            return res;
        }
    }
}
