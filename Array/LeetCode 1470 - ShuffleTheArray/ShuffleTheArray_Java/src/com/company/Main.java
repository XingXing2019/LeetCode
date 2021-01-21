package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {2,5,1,3,4,7};
        int n = 3;
        shuffle(nums, n);
    }
    public static int[] shuffle(int[] nums, int n) {
        int[] res = new int[nums.length];
        int p1 = 0, p2 = 1;
        for (int i = 0; i < nums.length; i++) {
            if(i < n){
                res[p1] = nums[i];
                p1 += 2;
            }
            else{
                res[p2] = nums[i];
                p2 += 2;
            }
        }
        return res;
    }
}
