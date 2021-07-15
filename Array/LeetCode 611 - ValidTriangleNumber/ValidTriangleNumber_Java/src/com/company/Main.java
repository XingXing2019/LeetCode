package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int triangleNumber(int[] nums) {
        Arrays.sort(nums);
        int res = 0;
        for (int i = nums.length - 1; i >= 0; i--) {
            int li = 0, hi = i - 1;
            while (li < hi){
                if(nums[li] + nums[hi] <= nums[i])
                    li++;
                else{
                    res += hi - li;
                    hi--;
                }
            }
        }
        return res;
    }
}
