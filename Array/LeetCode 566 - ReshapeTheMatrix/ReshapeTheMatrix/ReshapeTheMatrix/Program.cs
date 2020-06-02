//创建record数组记录nums中的每个数字。遍历nums，将数字计入record。创建行和列为r和c的res数组记录结果，遍历将record中的每个数字记录如res，并返回res。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReshapeTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] nums = new int[2][];
            nums[0] = new int[] { 1, 2 };
            nums[1] = new int[] { 3, 4 };
            int r = 1;
            int c = 4;
            Console.WriteLine(MatrixReshape(nums, r, c));
        }
        static int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            int row = nums.Length;
            int col = nums[0].Length;
            if (row * col != r * c)
                return nums;
            int[] record = new int[row * col];
            int index = 0;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    record[index++] = nums[i][j];
            index = 0;
            int[][] res = new int[r][];
            for (int i = 0; i < r; i++)
                res[i] = new int[c];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    res[i][j] = record[index++];
            return res;
        }
    }
}
