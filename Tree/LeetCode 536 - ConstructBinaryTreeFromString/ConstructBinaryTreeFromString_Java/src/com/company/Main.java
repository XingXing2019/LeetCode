package com.company;

class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode() {}
      TreeNode(int val) { this.val = val; }
      TreeNode(int val, TreeNode left, TreeNode right) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

public class Main {

    public static void main(String[] args) {
        String s = "4(2(3)(1))(6(5))";
        str2tree(s);
    }

    public static TreeNode str2tree(String s) {
        if(s.equals(null) || s.isEmpty()) return null;
        StringBuilder val = new StringBuilder();
        int index = 0;
        while (index < s.length() && s.charAt(index) != '(')
            val.append(s.charAt(index++));
        TreeNode root = new TreeNode(Integer.parseInt(val.toString()));
        String[] leftRight = getLeftRight(s.substring(index));
        root.left = str2tree(leftRight[0]);
        root.right = str2tree(leftRight[1]);
        return root;
    }
    public static String[] getLeftRight(String s){
        int left = 0;
        String[] res = new String[]{"", ""};
        for (int i = 0; i < s.length(); i++) {
            if(s.charAt(i) == '(')
                left++;
            else if(s.charAt(i) == ')')
                left--;
            if(left == 0){
                res[0] = s.substring(1, i);
                res[1] = i == s.length() - 1 ? "" : s.substring(i + 2, s.length() - 1);
                return res;
            }
        }
        return res;
    }
}
