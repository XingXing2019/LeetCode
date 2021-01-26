package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxCoins(int[] piles) {
        Arrays.sort(piles);
        int res = 0;
        for (int i = piles.length - 2; i >= piles.length / 3; i-=2)
            res += piles[i];
        return res;
    }
}
