package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean canJump(int[] nums) {
        int maxJump = 0;
        for (int i = 0; i < nums.length; i++) {
            maxJump = Math.max(maxJump, i + nums[i]);
            if (maxJump == i && i != nums.length - 1)
                return false;
        }
        return true;
    }
}
