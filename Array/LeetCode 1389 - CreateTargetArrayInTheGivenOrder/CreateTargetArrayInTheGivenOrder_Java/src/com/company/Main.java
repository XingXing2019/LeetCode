package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {0,1,2,3,4}, index = {0,1,2,2,1};
        createTargetArray(nums, index);
    }
    public static int[] createTargetArray(int[] nums, int[] index) {
        for (int i = 0; i < index.length; i++) {
            for (int j = i - 1; j >= 0; j--) {
                if(index[j] >= index[i])
                    index[j]++;
            }
        }
        var res = new int[nums.length];
        for (int i = 0; i < nums.length; i++)
            res[index[i]] = nums[i];
        return res;
    }
}
