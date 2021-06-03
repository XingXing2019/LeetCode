package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        int mod = 1_000_000_000 + 7;
        Arrays.sort(horizontalCuts);
        Arrays.sort(verticalCuts);
        long maxH = Math.max(horizontalCuts[0], h - horizontalCuts[horizontalCuts.length - 1]);
        long maxW = Math.max(verticalCuts[0], w - verticalCuts[verticalCuts.length - 1]);
        for (int i = 1; i < horizontalCuts.length; i++)
            maxH = Math.max(maxH, horizontalCuts[i] - horizontalCuts[i - 1]);
        for (int i = 1; i < verticalCuts.length; i++)
            maxW = Math.max(maxW, verticalCuts[i] - verticalCuts[i - 1]);
        return (int) (maxH * maxW % mod);
    }
}
