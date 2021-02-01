package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int hammingWeight(int n) {
        int res = 0, mask = 1;
        for (int i = 0; i < 32; i++) {
            if((n & mask) != 0)
                res++;
            mask <<= 1;
        }
        return res;
    }
}
