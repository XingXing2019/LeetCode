package com.company;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[] nums = {4, 2, 3};
        System.out.println(checkPossibility(nums));
    }

    public static boolean checkPossibility(int[] nums) {
        if (nums.length == 1) return true;
        int chance = 1;
        for (int i = 1; i < nums.length; i++) {
            if (nums[i] < nums[i - 1]) {
                if (chance == 1) {
                    if (i != 1 && nums[i] < nums[i - 2])
                        nums[i] = nums[i - 1];
                    else
                        nums[i - 1] = nums[i];
                    chance--;
                } else
                    return false;
            }
        }
        return true;
    }
}
