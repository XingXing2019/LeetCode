using System;
using System.Collections.Generic;

namespace VideoStitching
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = 10;
            int[][] clips = new int[12][];
            clips[0] = new int[] { 0, 1 };
            clips[1] = new int[] { 6, 8 };
            clips[2] = new int[] { 0, 2 };
            clips[3] = new int[] { 5, 6 };
            clips[4] = new int[] { 0, 4 };
            clips[5] = new int[] { 0, 3 };
            clips[6] = new int[] { 6, 7 };
            clips[7] = new int[] { 2, 6 };
            clips[8] = new int[] { 3, 4 };
            clips[9] = new int[] { 4, 5 };
            clips[10] = new int[] { 5, 7 };
            clips[11] = new int[] { 6, 9 };

            Console.WriteLine(VideoStitching(clips, T));
        }
        static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
        static int VideoStitching(int[][] clips, int T)
        {
            Sort<int>(clips, 1);
            Sort<int>(clips, 0);
            if (clips[0][0] != 0)
                return -1;
            int count = 1;
            int fastest = clips[0][1];
            for (int i = 1; i < clips.Length; i++)
            {
                if (clips[i][0] > fastest)
                    return -1;
                if (clips[i][0] <= fastest && clips[i][1] > fastest)
                {
                    count++;
                    fastest = clips[i][1];
                }
                if (clips[i - 1][0] >= clips[i][0] && clips[i - 1][1] <= clips[i][1])
                    count--;
                if (fastest >= T)
                    break;
            }
            return count;
        }
    }
}
