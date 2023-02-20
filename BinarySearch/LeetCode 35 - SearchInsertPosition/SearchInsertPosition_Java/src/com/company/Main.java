package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int searchInsert(int[] nums, int target) {
        var index = Arrays.binarySearch(nums, target);
        return index >= 0 ? index : ~index;
    }
}
