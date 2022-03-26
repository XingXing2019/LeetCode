package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int search(int[] nums, int target) {
        int li = 0, hi = nums.length - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] > target) hi = mid - 1;
            else li = mid + 1;
        }
        return -1;
    }
}
