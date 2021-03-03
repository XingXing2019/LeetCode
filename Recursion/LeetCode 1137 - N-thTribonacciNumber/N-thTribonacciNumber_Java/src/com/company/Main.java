package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int tribonacci(int n) {
        if(n < 1) return n;
        if(n < 3) return 1;
        int t1 = 0, t2 = 1, t3 = 1;
        for (int i = 0; i <= n - 3; i++) {
            int temp = t1 + t2 + t3;
            t1 = t2;
            t2 = t3;
            t3 = temp;
        }
        return t3;
    }
}
