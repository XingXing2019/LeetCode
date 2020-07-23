using System;

namespace ConstructBinaryTreeFromString
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
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
            var s = "-51(2(3)(1))(6(5))";
            Console.WriteLine(Str2tree(s));
        }
        static TreeNode Str2tree(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            string value = "";
            var index = 0;
            while (index < s.Length)
            {
                if(s[index] == '(') break;
                value += s[index];
                index++;
            }
            var root = new TreeNode(int.Parse(value));
            var leftAndRigth = SplitTree(s.Substring(index));
            root.left = Str2tree(leftAndRigth[0]);
            root.right = Str2tree(leftAndRigth[1]);
            return root;
        }

        static string[] SplitTree(string s)
        {
            if (s == "") return new string[2];
            int left = 1, right = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '(')
                    left++;
                else if (s[i] == ')')
                    right++;
                if (left == right)
                {
                    var leftS = s.Substring(1, i - 1);
                    var rigthS = i == s.Length - 1 ? "" : s.Substring(i + 2, s.Length - i - 3);
                    return new string[] {leftS, rigthS};
                }
            }
            return new string[2];
        }
    }
}
