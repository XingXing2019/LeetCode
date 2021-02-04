package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;

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
	// write your code here
    }

    public List<Double> averageOfLevels(TreeNode root) {
        List<Double> res = new ArrayList<>();
        if(root == null) return res;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            double sum = 0;
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                sum += cur.val;
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
            res.add(sum / count);
        }
        return res;
    }
}
