package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<List<Integer>> combine(int n, int k) {
        List<List<Integer>> res = new ArrayList<>();
        dfs(n, 1, k, new ArrayList<>(), res);
        return res;
    }

    public void dfs(int n, int start, int k, List<Integer> nums, List<List<Integer>> res) {
        if (nums.size() == k) {
            res.add(new ArrayList<>(nums));
            return;
        }
        for (int i = start; i <= n; i++) {
            nums.add(i);
            dfs(n, i + 1, k, nums, res);
            nums.remove(nums.size() - 1);
        }
    }
}
