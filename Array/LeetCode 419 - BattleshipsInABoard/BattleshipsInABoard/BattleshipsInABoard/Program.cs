//创建longShip记录长度大于1的船，shortShip记录长度等于1的船。
//遍历棋盘，遇到X则检查其四周有几个X，如有一个则证明其为shortShip，令shortShip加一。
//如果有一个则证明其为longShip，并且该点为船首或船尾。则令longShip加一。
//如果有两个则证明其为longShip，并且该点为船身，则不需要处理。
//最后返回shortShip加上longShip的一半。
using System;

namespace BattleshipsInABoard
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static int CountBattleships(char[][] board)
        {
            int longShip = 0, shortShip = 0;
            int row = board.Length;
            int col = board[0].Length;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (board[r][c] == 'X')
                    {
                        int arround = 0;
                        if (r != 0 && board[r - 1][c] == 'X')
                            arround++;
                        if (r != row - 1 && board[r + 1][c] == 'X')
                            arround++;
                        if (c != 0 && board[r][c - 1] == 'X')
                            arround++;
                        if (c != col - 1 && board[r][c + 1] == 'X')
                            arround++;
                        if (arround == 0)
                            shortShip++;
                        else if (arround == 1)
                            longShip++;
                    }
                }
            }
            return shortShip + longShip / 2;
        }
    }
}
