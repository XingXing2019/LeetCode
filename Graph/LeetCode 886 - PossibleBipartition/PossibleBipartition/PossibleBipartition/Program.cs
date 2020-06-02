//使用染色方法，将图中相邻的节点染成不同颜色。染色图中如果发现相邻节点与当前节点颜色相同则返回false。否则返回true。
using System;
using System.Collections.Generic;

namespace PossibleBipartition
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            int[][] dislikes = new int[4][]
            {
                new []{1, 2},
                new []{3, 4},
                new []{4, 5},
                new []{3, 5}
            };
        }

        class Person
        {
            public int Id { get; set; }
            public int Color { get; set; }
            public List<Person> Dislikes { get; set; }
            public Person(int x)
            {
                Id = x;
                Dislikes = new List<Person>();
            }
        }

        public bool PossibleBipartition_BFS(int N, int[][] dislikes)
        {
            var graph = new Person[N];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Person(i);
            foreach (var dislike in dislikes)
            {
                var person1 = graph[dislike[0] - 1];
                var person2 = graph[dislike[1] - 1];
                person1.Dislikes.Add(person2);
                person2.Dislikes.Add(person1);
            }
            var queue = new Queue<Person>();
            for (int i = 0; i < N; i++)
            {
                if (graph[i].Color != 0) continue;
                graph[i].Color = 1;
                queue.Enqueue(graph[i]);
                while (queue.Count != 0)
                {
                    var curPerson = queue.Dequeue();
                    foreach (var nextPerson in curPerson.Dislikes)
                    {
                        if (nextPerson.Color == curPerson.Color) return false;
                        if (nextPerson.Color != 0) continue;
                        nextPerson.Color = -curPerson.Color;
                        queue.Enqueue(nextPerson);
                    }
                }
            }
            return true;
        }

        public bool PossibleBipartition_DFS(int N, int[][] dislikes)
        {
            var graph = new Person[N];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Person(i);
            foreach (var dislike in dislikes)
            {
                var person1 = graph[dislike[0] - 1];
                var person2 = graph[dislike[1] - 1];
                person1.Dislikes.Add(person2);
                person2.Dislikes.Add(person1);
            }
            for (int i = 0; i < N; i++)
                if (graph[i].Color == 0 && !DFS(graph[i], 1, graph))
                    return false;
            return true;
        }

        private bool DFS(Person person, int color, Person[] graph)
        {
            person.Color = color;
            foreach (var nextPerson in person.Dislikes)
            {
                if (nextPerson.Color == person.Color) return false;
                if (nextPerson.Color == 0 && !DFS(nextPerson, -color, graph)) return false;
            }
            return true;
        }
    }
}
