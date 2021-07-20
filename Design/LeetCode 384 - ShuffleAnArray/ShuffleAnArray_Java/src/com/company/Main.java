package com.company;

import java.util.Arrays;
import java.util.Random;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class Solution {
    private int[] original;
    private int[] copy;
    private Random random;
    public Solution(int[] nums) {
        original = nums;
        random = new Random();
        copy = new int[nums.length];
        for (int i = 0; i < nums.length; i++)
            copy[i] =nums[i];
    }

    public int[] reset() {
        return original;
    }

    public int[] shuffle() {
        for (int i = 0; i < copy.length; i++) {
            int index = random.nextInt(copy.length);
            int temp = copy[i];
            copy[i] = copy[index];
            copy[index] = temp;
        }
        return copy;
    }
}
