package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] searchRange(int[] nums, int target) {
        int[] res = {-1, -1};
        if(nums.length == 0) return res;
        int li = 0, hi = nums.length - 1;
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            if(nums[mid] >= target) hi = mid - 1;
            else li = mid + 1;
        }
        if(li >= nums.length || nums[li] != target) return res;
        res[0] = li;
        li = 0;
        hi = nums.length - 1;
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            if(nums[mid] > target) hi = mid - 1;
            else li = mid + 1;
        }
        res[1] = hi;
        return res;
    }
}
