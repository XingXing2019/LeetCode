package com.company;

public class Main {

    public static void main(String[] args) {
        //            0, 1, 2, 3, 4, 5, 6, 7, 8
        int[] nums = {0, 0, 1, 1, 1, 1, 2, 3, 3};
        System.out.println(removeDuplicates(nums));
    }

    public static int removeDuplicates(int[] nums) {
        if (nums.length <= 2) return nums.length;
        int li = 0, hi = 1, chance = 1;
        while (hi < nums.length) {
            if (nums[li] == nums[hi]) {
                if (chance != 0) {
                    nums[++li] = nums[hi];
                    chance--;
                }
                hi++;
            } else {
                chance = 1;
                nums[++li] = nums[hi++];
            }
        }
        return li + 1;
    }
}
