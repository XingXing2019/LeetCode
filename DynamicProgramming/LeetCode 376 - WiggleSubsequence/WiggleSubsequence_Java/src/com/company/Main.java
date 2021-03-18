package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int wiggleMaxLength(int[] nums) {
        int res = 1, state = 0;
        for (int i = 1; i < nums.length; i++) {
            if (state == 0) {
                if (nums[i] == nums[i - 1]) continue;
                if (nums[i] > nums[i - 1]) state = 1;
                else if (nums[i] < nums[i - 1]) state = 2;
            } else if (state == 1 && nums[i] < nums[i - 1])
                state = 2;
            else if (state == 2 && nums[i] > nums[i - 1])
                state = 1;
            else
                continue;
            res++;
        }
        return res;
    }
}
