package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int findMin(int[] nums) {
        int li = 0, hi = nums.length - 1;
        while (li < hi){
            int mid = li + (hi - li) / 2;
            if(nums[mid] < nums[hi])
                hi = mid;
            else
                li = mid + 1;
        }
        return nums[li];
    }
}
