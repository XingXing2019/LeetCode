package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isPowerOfThree(int n) {
        if (n < 1) return false;
        while (n % 3 == 0)
            n /= 3;
        return n == 1;
    }
}
