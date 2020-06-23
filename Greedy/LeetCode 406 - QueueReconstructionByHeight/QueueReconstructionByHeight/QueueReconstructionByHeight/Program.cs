using System;
using System.Collections.Generic;
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

            Console.WriteLine(ReconstructQueue_Order(people));
        }
        static int[][] ReconstructQueue_Greedy(int[][] people)
        {
            people = people.OrderBy(x => x[0]).ToArray();
            var res = new int[people.Length][];
            foreach (var person in people)
            {
                int count = person[1];
                for (int i = 0; i < res.Length; i++)
                {
                    if (count == 0)
                    {
                        while (res[i] != null)
                            i++;
                        res[i] = person;
                        break;;
                    }
                    if (res[i] == null || res[i][0] >= person[0])
                        count--;
                }
            }
            return res;
        }
        static int[][] ReconstructQueue_Order(int[][] people)
        {
            people = people.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ToArray();
            var res = new List<int[]>();
            foreach (var person in people)
            {
                int index = person[1];
                res.Insert(index, person);
            }
            return res.ToArray();
        }
    }
}
