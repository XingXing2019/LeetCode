package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isPowerOfFour(int n) {
        if (n == 0) return false;
        while (n != 1) {
            if (n % 4 != 0)
                return false;
            n /= 4;
        }
        return true;
    }
}
