package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<List<Integer>> combinationSum3(int k, int n) {
        List<List<Integer>> res = new ArrayList<>();
        dfs(k, n, 0, 1, new ArrayList<>(), res);
        return res;
    }

    private void dfs(int k, int n, int start, int visited, List<Integer> nums, List<List<Integer>> res) {
        if (n < 0 || k < 0) return;
        if (n == 0 && k == 0) {
            res.add(new ArrayList<>(nums));
            return;
        }
        for (int i = start; i <= 9; i++) {
            if ((visited & (1 << i)) != 0) continue;
            nums.add(i);
            dfs(k - 1, n - i, i + 1, visited | (1 << i), nums, res);
            nums.remove(nums.size() - 1);
        }
    }
}
