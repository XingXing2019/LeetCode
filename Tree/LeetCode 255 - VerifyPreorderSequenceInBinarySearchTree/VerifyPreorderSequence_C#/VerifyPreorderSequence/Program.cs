using System;
using System.Linq;

namespace VerifyPreorderSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] preorder = { 5, 4, 2, 3, 1 };
            Console.WriteLine(VerifyPreorder(preorder));
        }
        public static bool VerifyPreorder(int[] preorder)
        {
            return DFS(preorder, 0, preorder.Length - 1);
        }

        public static bool DFS(int[] preorder, int li, int hi)
        {
            if (li >= hi) return true;
            var index = li + 1;
            while (index <= hi && preorder[index] < preorder[li])
                index++;
            for (int i = index; i < preorder.Length; i++)
            {
                if (preorder[i] <= preorder[li])
                    return false;
            }
            return DFS(preorder, li + 1, index - 1) && DFS(preorder, index, hi);
        }
    }
}
