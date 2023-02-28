package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    TreeNode() {
    }

    TreeNode(int val) {
        this.val = val;
    }

    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Main {

    public static void main(String[] args) {
        TreeNode a = new TreeNode(0);
        TreeNode b = new TreeNode(0);
        TreeNode c = new TreeNode(0);
        TreeNode d = new TreeNode(0);
        TreeNode e = new TreeNode(0);
        TreeNode f = new TreeNode(0);

        a.left = b;
        a.right = c;
        b.left = d;
        c.right = e;
        e.right = f;

        System.out.println(findDuplicateSubtrees(a));
    }

    public static List<TreeNode> findDuplicateSubtrees(TreeNode root) {
        Map<String, List<TreeNode>> map = new HashMap<>();
        dfs(root, map);
        List<TreeNode> res = new ArrayList<>();
        for (String pattern : map.keySet()) {
            if (map.get(pattern).size() == 1) continue;
            res.add(map.get(pattern).get(0));
        }
        return res;
    }

    public static String dfs(TreeNode node, Map<String, List<TreeNode>> map) {
        if (node == null)
            return "#";
        String left = dfs(node.left, map);
        String right = dfs(node.right, map);
        String cur = + node.val + "," + left + "," + right;
        if (!map.containsKey(cur))
            map.put(cur, new ArrayList<>());
        map.get(cur).add(node);
        return cur;
    }
}
