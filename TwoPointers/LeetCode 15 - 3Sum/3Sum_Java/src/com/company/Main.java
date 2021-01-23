package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<List<Integer>> threeSum(int[] nums) {
        List<List<Integer>> res = new ArrayList<>();
        Arrays.sort(nums);
        for (int i = 0; i < nums.length - 2; i++) {
            if(i != 0 && nums[i] == nums[i - 1]) continue;
            int target = -nums[i];
            int li = i + 1, hi  = nums.length - 1;
            while(li < hi){
                if(nums[li] + nums[hi] == target){
                    int num1 = nums[i], num2 = nums[li], num3 = nums[hi];
                    res.add(new ArrayList<>(){{add(num1); add(num2); add(num3);}});
                    while(li < hi && nums[li] == num2)
                        li++;
                    hi--;
                }
                else if (nums[li] + nums[hi] > target)
                    hi--;
                else
                    li++;
            }
        }
        return res;
    }
}
