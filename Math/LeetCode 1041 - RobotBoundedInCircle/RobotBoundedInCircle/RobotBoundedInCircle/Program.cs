//记录一下最后机器人的方向，和向东西南北各个方向所走的距离。
//最后如果方向不是向北，或者能回到原点(东西方向距离相等，南北方向距离相等)，则但会true。
using System;

namespace RobotBoundedInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool IsRobotBounded(string instructions)
        {
            int North = 0, South = 0, West = 0, East = 0;
            string direction = "north";
            for (int i = 0; i < instructions.Length; i++)
            {
                if (instructions[i] == 'L')
                {
                    if (direction == "north")
                        direction = "west";
                    else if (direction == "south")
                        direction = "east";
                    else if (direction == "west")
                        direction = "south";
                    else if (direction == "east")
                        direction = "north";
                }
                else if (instructions[i] == 'R')
                {
                    if (direction == "north")
                        direction = "east";
                    else if (direction == "south")
                        direction = "west";
                    else if (direction == "west")
                        direction = "north";
                    else if (direction == "east")
                        direction = "south";
                }
                else
                {
                    if (direction == "north")
                        North++;
                    else if (direction == "south")
                        South++;
                    else if (direction == "west")
                        West++;
                    else if (direction == "east")
                        East++;
                }
            }
            return direction != "north" || North == South && East == West;
        }
    }
}
