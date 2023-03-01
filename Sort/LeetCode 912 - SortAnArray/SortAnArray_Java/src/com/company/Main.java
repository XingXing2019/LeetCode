package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {3, 2, 1};
        System.out.println(sortArray(nums));
    }

    public static int[] sortArray(int[] nums) {
        return sort(nums, 0, nums.length - 1);
    }

    public static int[] sort(int[] nums, int li, int hi) {
        if (li > hi)
            return null;
        if (li == hi)
            return new int[]{nums[li]};
        int mid = (hi - li) / 2;
        int[] left = sort(nums, li, li + mid);
        int[] right = sort(nums, li + mid + 1, hi);
        return merge(left, right);
    }

    public static int[] merge(int[] left, int[] right) {
        if (left == null) return right;
        if (right == null) return left;
        int p1 = 0, p2 = 0, p3 = 0;
        int[] res = new int[left.length + right.length];
        while (p1 < left.length && p2 < right.length)
            res[p3++] = left[p1] < right[p2] ? left[p1++] : right[p2++];
        while (p1 < left.length)
            res[p3++] = left[p1++];
        while (p2 < right.length)
            res[p3++] = right[p2++];
        return res;
    }
}
