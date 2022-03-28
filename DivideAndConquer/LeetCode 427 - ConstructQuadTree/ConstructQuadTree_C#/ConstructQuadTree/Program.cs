using System;

namespace ConstructQuadTree
{
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid =
            {
                new[] { 1, 0 },
                new[] { 1, 0 },
            };
            Console.WriteLine(Construct(grid));
        }

        public static Node Construct(int[][] grid)
        {
            int top = 0, bottom = grid.Length - 1;
            int left = 0, right = grid[0].Length - 1;
            return DFS(grid, top, bottom, left, right);
        }

        public static Node DFS(int[][] grid, int top, int bottom, int left, int right)
        {
            if (AllSame(grid, top, bottom, left, right))
                return new Node(grid[top][left] == 1, true);
            var root = new Node(false, false);
            var size = (bottom - top + 1) / 2;
            root.topLeft = DFS(grid, top, top + size - 1, left, left + size - 1);
            root.topRight = DFS(grid, top, top + size - 1, right - size + 1, right);
            root.bottomLeft = DFS(grid, bottom - size + 1, bottom, left, left + size - 1);
            root.bottomRight = DFS(grid, bottom - size + 1, bottom, right - size + 1, right);
            return root;
        }

        public static bool AllSame(int[][] grid, int top, int bottom, int left, int right)
        {
            var val = grid[top][left];
            for (int i = top; i <= bottom; i++)
            {
                for (int j = left; j <= right; j++)
                {
                    if (grid[i][j] != val)
                        return false;
                }
            }
            return true;
        }
    }
}
