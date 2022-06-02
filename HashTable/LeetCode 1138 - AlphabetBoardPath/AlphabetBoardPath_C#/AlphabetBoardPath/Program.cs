//创建6行5列的二维数组record，将其用0-29填满。创建map字典，将record中每个数字和其坐标加入map。
//创建start代表起点，遍历字符串，创建end代表终点。如果起点不等于终点，则查找start和end在map中的坐标，并做相应的移动使起点到达终点，并将'!'加入结果。需要注意字母为'z'的情况应作出特殊处理。
using System;
using System.Collections.Generic;

namespace AlphabetBoardPath
{
    class Program
    {
        static void Main(string[] args)
        {
            string target = "zdz";
            Console.WriteLine(AlphabetBoardPath(target));
        }
        static string AlphabetBoardPath(string target)
        {
            int[,] record = new int[6, 5];
            int tem = 0;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 5; j++)
                    record[i, j] = tem++;
            var map = new Dictionary<int, int[] >();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 5; j++)
                    map[record[i, j]] = new int[2] { i, j };
            string res = "";
            int start = 0;
            for (int i = 0; i < target.Length; i++)
            {
                int end = target[i] - 'a';
                if(start != end)
                {
                    int rou = map[end][0] - map[start][0];
                    int col = map[end][1] - map[start][1];
                    if(end == 25)
                    {
                        for (int j = 0; j < rou - 1; j++)
                            res += "D";
                        for (int j = 0; j < -col; j++)
                            res += "L";
                        res += "D";
                    }
                    else
                    {
                        if (rou > 0)
                            for (int j = 0; j < rou; j++)
                                res += "D";
                        else
                            for (int j = 0; j < -rou; j++)
                                res += "U";
                        if (col > 0)
                            for (int j = 0; j < col; j++)
                                res += "R";
                        else
                            for (int j = 0; j < -col; j++)
                                res += "L";
                    }
                    start = end;
                }
                res += "!";
            }
            return res;
        }
    }
}
