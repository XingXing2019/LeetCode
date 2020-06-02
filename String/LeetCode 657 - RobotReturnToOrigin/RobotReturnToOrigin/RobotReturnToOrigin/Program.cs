//创建horizontal和vertical记录水平和垂直的位置。
//遍历字符串，根据不同的字符决定horizontal和vertical的加减。
//最后判断horizontal和vertical是否都为0.
using System;

namespace RobotReturnToOrigin
{
    class Program
    {
        static void Main(string[] args)
        {
            string moves = "";
            Console.WriteLine(JudgeCircle1(moves));
        }
        static bool JudgeCircle1(string moves)
        {
            int[,] position = new int[1, 2];
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'U')
                    position[0, 0]++;
                else if (moves[i] == 'D')
                    position[0, 0]--;
                else if (moves[i] == 'L')
                    position[0, 1]++;
                else if (moves[i] == 'R')
                    position[0, 1]--;
            }
            if (position[0, 0] == 0 && position[0, 1] == 0)
                return true;
            else
                return false;
        }
        static bool JudgeCircle2(string moves)
        {
            int horizontal = 0;
            int vertical = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'U')
                    vertical++;
                else if (moves[i] == 'D')
                    vertical--;
                else if (moves[i] == 'L')
                    horizontal++;
                else if (moves[i] == 'R')
                    horizontal--;
            }
            return horizontal == 0 && vertical == 0;
        }
    }
}
