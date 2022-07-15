using System;

namespace LogicalOr
{
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;
        public Node() { }
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
            Console.WriteLine("Hello World!");
        }

        public Node Intersect(Node quadTree1, Node quadTree2)
        {
            if (quadTree1.isLeaf)
                return quadTree1.val ? new Node(true, true, null, null, null, null) : quadTree2;
            if (quadTree2.isLeaf)
                return quadTree2.val ? new Node(true, true, null, null, null, null) : quadTree1;
            var topLeft = Intersect(quadTree1.topLeft, quadTree2.topLeft);
            var topRight = Intersect(quadTree1.topRight, quadTree2.topRight);
            var bottomLeft = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
            var bottomRight = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);
            var allLeaves = topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf;
            var allTrue = topLeft.val && topRight.val && bottomLeft.val && bottomRight.val;
            if (allLeaves && allTrue)
                return new Node(true, true, null, null, null, null);
            return new Node(true, false, topLeft, topRight, bottomLeft, bottomRight);
        }
    }
}
