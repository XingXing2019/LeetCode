using System;

namespace CheckIfTwoExpressionTreesAreEquivalent
{
    public class Node
    {
        public char val;
        public Node left;
        public Node right;
        public Node(char val = ' ', Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool CheckEquivalence(Node root1, Node root2)
        {
            int[] letters1 = new int[26], letters2 = new int[26];
            DFS(root1, letters1);
            DFS(root2, letters2);
            for (int i = 0; i < 26; i++)
            {
                if (letters1[i] != letters2[i])
                    return false;
            }
            return true;
        }

        static void DFS(Node node, int[] letters)
        {
            if(node == null) return;
            if (char.IsLetter(node.val))
                letters[node.val - 'a']++;
            DFS(node.left, letters);
            DFS(node.right, letters);
        }
    }
}
