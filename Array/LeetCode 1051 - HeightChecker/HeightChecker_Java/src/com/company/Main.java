package com.company;

import java.util.Arrays;
import java.util.Collections;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int heightChecker(int[] heights) {
        int[] copy = Arrays.copyOf(heights, heights.length);
        Arrays.sort(heights);
        int res = 0;
        for (int i = 0; i < heights.length; i++) {
            if (heights[i] == copy[i]) continue;
            res++;
        }
        return res;
    }
}
