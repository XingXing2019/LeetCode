package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {4, 5, 6, 7, 0, 1, 2};
        int target = 0;
        System.out.println(search(nums, target));
    }

    public static int search(int[] nums, int target) {
        int li = 0, hi = nums.length - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] >= nums[li]) {
                if (nums[li] <= target && target < nums[mid])
                    hi = mid - 1;
                else
                    li = mid + 1;
            } else {
                if (nums[mid] < target && target <= nums[hi])
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
        }
        return -1;
    }
}
