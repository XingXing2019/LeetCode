using System;
using System.Linq;

namespace QueueReconstructionByHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] people = new int[6][];
            people[0] = new int[] {7, 0};
            people[1] = new int[] {4, 4};
            people[2] = new int[] {7, 1};
            people[3] = new int[] {5, 0};
            people[4] = new int[] {6, 1};
            people[5] = new int[] {5, 2};

            Console.WriteLine(ReconstructQueue(people));
        }
        static int[][] ReconstructQueue(int[][] people)
        {
            people = people.OrderBy(p => p[0]).ToArray();
            var res = new int[people.Length][];
            foreach (var person in people)
            {
                int count = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    if (person[1] == count && res[i] == null)
                    {
                        res[i] = person;
                        break;
                    }
                    if (res[i] == null || res[i][0] >= person[0])
                        count++;
                }
            }
            return res;
        }
    }
}
