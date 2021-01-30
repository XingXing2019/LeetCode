using System;
using System.Collections.Generic;

namespace AsteroidCollision
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] asteroids = { -2, -1, 1, 2 };
            Console.WriteLine(AsteroidCollision(asteroids));
        }
        static int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            foreach (var a in asteroids)
            {
                if (stack.Count != 0 && a < 0 && stack.Peek() > 0)
                {
                    while (stack.Count != 0 && stack.Peek() > 0 && Math.Abs(a) > stack.Peek())
                        stack.Pop();
                    if (stack.Count != 0 && stack.Peek() < 0 || stack.Count == 0)
                        stack.Push(a);
                    else if (stack.Count != 0 && stack.Peek() == -a)
                        stack.Pop();
                }
                else
                    stack.Push(a);
            }
            var res = new int[stack.Count];
            int index = res.Length - 1;
            while (stack.Count != 0)
                res[index--] = stack.Pop();
            return res;
        }
    }
}
