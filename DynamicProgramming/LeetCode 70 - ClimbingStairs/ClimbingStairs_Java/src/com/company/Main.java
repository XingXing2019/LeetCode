package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int climbStairs(int n) {
        if (n < 3) return n;
        int first = 1, second = 2;
        for (int i = 2; i < n; i++) {
            int temp = first + second;
            first = second;
            second = temp;
        }
        return second;
    }
}
