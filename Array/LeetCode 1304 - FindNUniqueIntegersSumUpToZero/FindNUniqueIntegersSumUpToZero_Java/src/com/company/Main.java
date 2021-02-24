package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] sumZero(int n) {
        int[] res = new int[n];
        if(n % 2 == 0) n++;
        for (int i = 0; i < n - 1; i++) {
            res[i] = i % 2 == 0 ? -(i + 1) : i;
        }
        return res;
    }
}
