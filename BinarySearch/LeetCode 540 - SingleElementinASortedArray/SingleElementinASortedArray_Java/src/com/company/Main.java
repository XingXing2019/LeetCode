package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int singleNonDuplicate(int[] nums) {
        int li = 1, hi = nums.length - 1;
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            if(mid % 2 == 0){
                if(nums[mid] == nums[mid - 1]) hi = mid - 1;
                else li = mid + 1;
            }
            else {
                if(nums[mid] == nums[mid - 1]) li = mid + 1;
                else hi = mid - 1;
            }
        }
        return nums[hi];
    }
}
