using System;
using System.Collections.Generic;

namespace ExamRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ExamRoom
    {
        private SortedSet<int> students;
        private int n;
        public ExamRoom(int n)
        {
            this.students = new SortedSet<int>();
            this.n = n;
        }

        public int Seat()
        {
            int seat = 0, dist = students.Min, pre = -1;
            foreach (var student in students)
            {
                if (pre != -1)
                {
                    var d = (student - pre) / 2;
                    if (d > dist)
                    {
                        dist = d;
                        seat = d + pre;
                    }
                }
                pre = student;
            }
            if (students.Count != 0 && n - 1 - pre > dist)
                seat = n - 1;
            students.Add(seat);
            return seat;
        }

        public void Leave(int p)
        {
            students.Remove(p);
        }
    }
}
