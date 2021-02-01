package com.company;

public class Main {

    public static void main(String[] args) {
	    int[] nums = {3, 2, 2, 3};
	    int val = 2;
	    removeElement(nums, val);
    }

    public static int removeElement(int[] nums, int val) {
        int li = 0, hi = 0;
        while (hi < nums.length){
            if(nums[hi] != val)
                nums[li++] = nums[hi];
            hi++;
        }
        return li;
    }
}
