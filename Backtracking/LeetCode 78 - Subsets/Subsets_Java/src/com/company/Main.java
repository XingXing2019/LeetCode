package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	    int[] nums = {1, 2, 3};
        System.out.println(subsets(nums));
    }

    public static List<List<Integer>> subsets(int[] nums) {
        List<List<Integer>> res = new ArrayList<>();
        dfs(res, nums, new ArrayList<>(), 0);
        return res;
    }

    public static void dfs(List<List<Integer>> res, int[] nums, List<Integer> items, int start){
        res.add(new ArrayList<>(items));
        for (int i = start; i < nums.length; i++) {
            items.add(nums[i]);
            dfs(res, nums, items, i + 1);
            items.remove(items.size() - 1);
        }
    }
}
