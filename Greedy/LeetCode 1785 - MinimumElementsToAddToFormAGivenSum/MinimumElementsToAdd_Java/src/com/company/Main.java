package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int minElements(int[] nums, int limit, int goal) {
        double sum = 0;
        for (int num : nums) sum += num;
        double diff = Math.abs(goal - sum);
        return (int) Math.ceil(diff / limit);
    }
}
