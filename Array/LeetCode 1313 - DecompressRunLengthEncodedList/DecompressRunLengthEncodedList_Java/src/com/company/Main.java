package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] decompressRLElist(int[] nums) {
        var size = 0;
        for (int i = 0; i < nums.length; i+=2)
            size += nums[i];
        var res = new int[size];
        var index = 0;
        for (int i = 0; i < nums.length - 1; i+=2) {
            var count = nums[i];
            for (int j = 0; j < count; j++)
                res[index++] = nums[i + 1];
        }
        return res;
    }
}
