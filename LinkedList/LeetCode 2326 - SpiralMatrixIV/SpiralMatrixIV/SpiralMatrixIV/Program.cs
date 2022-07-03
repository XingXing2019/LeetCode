using System;

namespace SpiralMatrixIV
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            var res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
                Array.Fill(res[i], -1);
            }
            int x = 0, y = 0, index = 0;
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };
            while (head != null)
            {
                res[x][y] = head.val;
                int newX = x + dx[index % 4], newY = y + dy[index % 4];
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || res[newX][newY] != -1)
                {
                    index++;
                    newX = x + dx[index % 4];
                    newY = y + dy[index % 4];
                }
                x = newX;
                y = newY;
                head = head.next;
            }
            return res;
        }

    }
}
