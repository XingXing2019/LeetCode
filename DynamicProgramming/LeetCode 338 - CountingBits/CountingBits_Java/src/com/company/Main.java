package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] countBits(int num) {
        if(num < 1) return new int[1];
        int[] res = new int[num + 1];
        res[1] = 1;
        for (int i = 0; i < res.length; i++) {
            if(i % 2 == 0) res[i] = res[i / 2];
            else res[i] = res[i - 1] + 1;
        }
        return res;
    }
}
