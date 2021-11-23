package com.company;

import java.util.Arrays;
import java.util.Random;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class Solution {
    int[] weight;
    Random random;
    public Solution(int[] w) {
        random = new Random();
        weight = w;
        for (int i = 1; i < weight.length; i++)
            weight[i] += weight[i - 1];
    }

    public int pickIndex() {
        var w = random.nextInt(weight[weight.length - 1]) + 1;
        var index = Arrays.binarySearch(weight, w);
        if (index < 0) index = ~index;
        return index;
    }
}
