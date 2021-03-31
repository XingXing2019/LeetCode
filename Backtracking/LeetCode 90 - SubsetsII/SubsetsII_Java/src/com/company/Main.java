package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 2, 2};
        System.out.println(subsetsWithDup(nums));
    }
    public static List<List<Integer>> subsetsWithDup(int[] nums) {
        Arrays.sort(nums);
        List<List<Integer>> res = new ArrayList<>();
        dfs(nums, 0, new ArrayList<>(), res);
        return res;
    }

    public static void dfs(int[] nums, int start, List<Integer> item, List<List<Integer>> res){
        res.add(new ArrayList<>(item));
        for (int i = start; i < nums.length; i++) {
            if(i > start && nums[i] == nums[i - 1]) continue;
            item.add(nums[i]);
            dfs(nums, i + 1, item, res);
            item.remove(item.size() - 1);
        }
    }
}
