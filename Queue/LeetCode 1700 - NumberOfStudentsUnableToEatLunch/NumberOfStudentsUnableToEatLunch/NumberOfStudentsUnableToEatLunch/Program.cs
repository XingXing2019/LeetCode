using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfStudentsUnableToEatLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] students = { 1, 1, 1, 0, 0, 1 };
            int[] sandwiches = { 1, 0, 0, 0, 1, 1 };
            Console.WriteLine(CountStudents(students, sandwiches));
        }
        static int CountStudents(int[] students, int[] sandwiches)
        {
            int[] preference = { students.Count(x => x == 0), students.Count(x => x == 1) };
            var queue = new Queue<int>(students);
            int index = 0;
            while (index < sandwiches.Length && preference[sandwiches[index]] != 0)
            {
                if (queue.Peek() == sandwiches[index])
                {
                    queue.Dequeue();
                    preference[sandwiches[index]]--;
                    index++;
                }
                else
                    queue.Enqueue(queue.Dequeue());
            }
            return queue.Count;
        }
    }
}
