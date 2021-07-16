package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1,0,-1,0,-2,2};
        int target = 0;
        System.out.println(fourSum(nums, target));
    }

    public static List<List<Integer>> fourSum(int[] nums, int target) {
        Arrays.sort(nums);
        List<List<Integer>> res = new ArrayList<>();
        int lastI = nums[0] - 1;
        for (int i = 0; i < nums.length - 3; i++) {
            if (nums[i] == lastI) continue;
            lastI = nums[i];
            int lastJ = nums[i + 1] - 1;
            for (int j = i + 1; j < nums.length - 2; j++) {
                if (nums[j] == lastJ) continue;
                lastJ = nums[j];
                int li = j + 1, hi = nums.length - 1;
                while (li < hi) {
                    if (nums[i] + nums[j] + nums[li] + nums[hi] == target) {
                        List<Integer> temp = new ArrayList<>();
                        temp.add(nums[i]);
                        temp.add(nums[j]);
                        temp.add(nums[li++]);
                        temp.add(nums[hi--]);
                        res.add(temp);
                        while (li < hi && nums[li] == temp.get(2))
                            li++;
                    }
                    else if (nums[i] + nums[j] + nums[li] + nums[hi] > target)
                        hi--;
                    else
                        li++;
                }
            }
        }
        return res;
    }
}
