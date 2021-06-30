package com.company;

class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }

public class Main {

    public static void main(String[] args) {
        TreeNode a = new TreeNode(1);
        TreeNode b = new TreeNode(2);
        TreeNode c = new TreeNode(3);
        TreeNode d = new TreeNode(4);
        TreeNode e = new TreeNode(5);

        a.left = b;
        a.right = c;
        c.left = d;
        c.right = e;

        Codec codec = new Codec();
        String code = codec.serialize(a);
        TreeNode root = codec.deserialize(code);
    }
}

class Codec {
    int index;
    public String serialize(TreeNode root) {
        StringBuilder res = new StringBuilder();
        preorder(root, res);
        return res.toString();
    }
    private void preorder(TreeNode node, StringBuilder str){
        if(node == null) {
            str.append("#,");
            return;
        }
        str.append(node.val + ",");
        preorder(node.left, str);
        preorder(node.right, str);
    }
    public TreeNode deserialize(String data) {
        String[] nodes = data.split(",");
        return build(nodes);
    }
    private TreeNode build(String[] nodes){
        String node = nodes[index++];
        if(node.equals("#"))
            return null;
        TreeNode root = new TreeNode(Integer.parseInt(node));
        root.left = build(nodes);
        root.right = build(nodes);
        return root;
    }
}
