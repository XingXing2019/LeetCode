using System;
using System.Diagnostics.Tracing;

namespace WalkingRobotSimulationII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot(2, 2);

            robot.Move(16);
        }
    }

    public class Robot
    {

        private int x;
        private int y;
        private int index;
        private int[] dimension;
        public Robot(int width, int height)
        {
            this.dimension = new[] { width, height };
        }

        public void Move(int num)
        {
            if (x == 0 && y == 0 && index % 4 == 0 && num % (dimension[0] * 2 + dimension[1] * 2 - 4) == 0)
                index = 3;
            num %= dimension[0] * 2 + dimension[1] * 2 - 4;
            var dir = new[] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 } };
            if (index % 2 == 0)
            {
                if (index % 4 == 0 && num > dimension[index % 2] - x - 1)
                {
                    num -= dimension[index % 2] - x - 1;
                    x = dimension[index % 2] - 1;
                    index++;
                }
                else if (index % 4 != 0 && num > x)
                {
                    num -= x;
                    x = 0;
                    index++;
                }
            }
            else
            {
                if (index % 4 == 1 && num > dimension[index % 2] - y - 1)
                {
                    num -= dimension[index % 2] - y - 1;
                    y = dimension[index % 2] - 1;
                    index++;
                }
                else if (index % 4 != 1 && num > y)
                {
                    num -= y;
                    y = 0;
                    index++;
                }
            }
            while (num > dimension[index % 2] - 1)
            {
                num -= dimension[index % 2] - 1;
                if (index % 2 == 0)
                    x = index % 4 == 0 ? dimension[index % 2] - 1 : 0;
                else
                    y = index % 4 == 1 ? dimension[index % 2] - 1 : 0;
                index++;
            }
            x += dir[index % 4][0] * num;
            y += dir[index % 4][1] * num;
        }

        public int[] GetPos()
        {
            return new[] { x, y };
        }

        public string GetDir()
        {
            var direction = new[] { "East", "North", "West", "South" };
            return direction[index % 4];
        }
    }
}
