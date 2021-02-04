package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int findDuplicate_FloydTortoiseAndHase(int[] nums) {
        int tortoise = 0, hase = 0;
        boolean firstMeet = true;
        while (tortoise != hase || firstMeet){
            tortoise = nums[tortoise];
            hase = nums[hase];
            hase = nums[hase];
            if(tortoise == hase) firstMeet = false;
        }
        hase = 0;
        while (tortoise != hase){
            tortoise = nums[tortoise];
            hase = nums[hase];
        }
        return hase;
    }
    public int findDuplicate_ModifyArray(int[] nums) {
        for (int i = 0; i < nums.length; i++) {
            if(nums[Math.abs(nums[i])] < 0) return Math.abs(nums[i]);
            nums[Math.abs(nums[i])] *= -1;
        }
        return -1;
    }
}
