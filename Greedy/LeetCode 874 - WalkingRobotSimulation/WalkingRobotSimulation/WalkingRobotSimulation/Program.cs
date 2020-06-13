//用HashSet将障碍物变成字符串记录一下。
//创建一个方向数组，按上右下左的顺序设置方向，并创建一个pointer指针。当右转时，pointer加1，左转时，pointer加3。那么point % 4就正好在方向数组中指向要行走的方向。
//前进时要一步一步前进，如果发现进入障碍物坐标，做倒退一步并停止。每次停止后更新一下最大的距离。
using System;
using System.Collections.Generic;

namespace WalkingRobotSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = { 4, -1, 4, -2, 4 };
            int[][] obstacles = new int[][] { new int[] { 2, 4 } };
            Console.WriteLine(RobotSim(commands, obstacles));
        }
        static int RobotSim(int[] commands, int[][] obstacles)
        {
            var ob = new HashSet<string>();
            foreach (var obstacle in obstacles)
                ob.Add($"{obstacle[0]},{obstacle[1]}");
            var directions = new int[4][]
            {
                new[] {0, 1},
                new[] {1, 0},
                new[] {0, -1},
                new[] {-1, 0}
            };
            int x = 0, y = 0, pointer = 0, res = 0;
            foreach (var command in commands)
            {
                if (command == -1)
                    pointer += 1;
                else if (command == -2)
                    pointer += 3;
                else
                {
                    for (int i = 0; i < command; i++)
                    {
                        x += directions[pointer % 4][0];
                        y += directions[pointer % 4][1];
                        if (ob.Contains($"{x},{y}"))
                        {
                            x -= directions[pointer % 4][0];
                            y -= directions[pointer % 4][1];
                            break;
                        }
                    }
                    res = Math.Max(res, x * x + y * y);
                }
            }
            return res;
        }
    }
}
