﻿//与LeetCode-54思路一样，只是过程相反。注意需要先初始化res，将n个长度为n的数组存入res。
//创建height和width代表res的高和宽，初始值设为n。创建startR和startC指针用来指向当前的行和列。
//创建num用来记录当前需要写入数组的数字。
//在num小于等于n平方的条件下遍历。依次在res的上右下左各边写入数字。做法和LeetCode-54一样。注意每写入一次数据就让num加一。
using System;
using System.Collections.Generic;

namespace SpiralMatrixII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Console.WriteLine(GenerateMatrix(n));
        }
        static int[][] GenerateMatrix(int n)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
                res[i] = new int[n];
            int height = n;
            int width = n;
            int startR = 0;
            int startC = 0;
            int num = 1;
            while (num <= n * n)
            {
                for (int i = startC; i < startC + width; i++)
                {
                    res[startR][i] = num;
                    num++;
                }
                height--;
                startR++;
                for (int i = startR; i < height + startR; i++)
                {
                    res[i][width + startC - 1] = num;
                    num++;
                }
                width--;
                for (int i = width + startC - 1; i >= startC; i--)
                {
                    res[height + startR - 1][i] = num;
                    num++;
                }
                height--;
                for (int i = height + startR - 1; i >= startR; i--)
                {
                    res[i][startC] = num;
                    num++;
                }
                width--;
                startC++;
            }
            return res;
        }

        static int[][] GenerateMatrix_DirectionArray(int n)
        {
            var res = new int[n][];
            for (int i = 0; i < res.Length; i++)
                res[i] = new int[n];
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };
            int direction = 0;
            int x = 0, y = 0;
            var visited = new HashSet<string>();
            for (int i = 1; i <= n * n && visited.Count < n * n; i++)
            {
                res[x][y] = i;
                visited.Add($"{x}:{y}");
                int newX = x + dx[direction % 4];
                int newY = y + dy[direction % 4];
                if (newX < 0 || newX >= n || newY < 0 || newY >= n || visited.Contains($"{newX}:{newY}"))
                {
                    direction++;
                    i--;
                }
                else
                {
                    x = newX;
                    y = newY;
                }
            }
            return res;
        }
    }
}
