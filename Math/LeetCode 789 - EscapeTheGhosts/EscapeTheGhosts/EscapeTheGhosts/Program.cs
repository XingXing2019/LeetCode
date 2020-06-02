//只要你能比鬼先到target就可以逃脱。
//创建StepsToTarget方法计算到target所需的步数。
//在主方法中计算你到达target所需的步数和所有鬼中，到达target最少的步数。
//返回你的步数小于贵的步数。
using System;

namespace EscapeTheGhosts
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] start = { 2, 3 };
            int[] target = { 1, 1 };
            Console.WriteLine(StepsToTarget(start, target));
        }
        static bool EscapeGhosts(int[][] ghosts, int[] target)
        {
            int yourSteps = StepsToTarget(new int[2] { 0, 0 }, target);
            int ghostMinSteps = int.MaxValue;
            foreach (var g in ghosts)
            {
                int ghostSteps = StepsToTarget(g, target);
                ghostMinSteps = Math.Min(ghostMinSteps, ghostSteps);
            }
            return yourSteps < ghostMinSteps;
        }
        static int StepsToTarget(int[] start, int[] target)
        {
            return Math.Abs(target[0] - start[0]) + Math.Abs(target[1] - start[1]);
        }
    }
}
