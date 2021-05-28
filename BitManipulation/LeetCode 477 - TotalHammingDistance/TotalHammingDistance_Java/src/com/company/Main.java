package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int totalHammingDistance(int[] nums) {
        int res = 0;
        for (int i = 0; i < 32; i++) {
            int zero = 0, one = 0;
            for (int num : nums){
                if(((num >> i) & 1) == 1) one++;
                else zero++;
            }
            res += zero * one;
        }
        return res;
    }
}
