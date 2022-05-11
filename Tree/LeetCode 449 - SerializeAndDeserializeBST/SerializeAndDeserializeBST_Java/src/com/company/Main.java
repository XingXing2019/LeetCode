package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {
    class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;

        TreeNode(int x) {
            val = x;
        }
    }

    public static void main(String[] args) {
        // write your code here
    }

    public class Codec {
        int index;
        // Encodes a tree to a single string.
        public String serialize(TreeNode root) {
            StringBuilder nodes = new StringBuilder();
            dfs(root, nodes);
            return nodes.toString();
        }

        private void dfs(TreeNode root, StringBuilder nodes) {
            if (root == null) {
                nodes.append("#,");
                return;
            }
            nodes.append(root.val + ",");
            dfs(root.left, nodes);
            dfs(root.right, nodes);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(String data) {
            String[] nodes = data.split(",");
            return build(nodes);
        }

        public TreeNode build(String[] nodes) {
            String node = nodes[index++];
            if (node.equals("#")) return null;
            TreeNode root = new TreeNode(Integer.parseInt(node));
            root.left = build(nodes);
            root.right = build(nodes);
            return root;
        }
    }
}
