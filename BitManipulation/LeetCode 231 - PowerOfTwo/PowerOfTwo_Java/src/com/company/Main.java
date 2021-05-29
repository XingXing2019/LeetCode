package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isPowerOfTwo(int n) {
        if (n == 0) return false;
        while (n != 1) {
            if ((n & 1) == 1)
                return false;
            n >>= 1;
        }
        return true;
    }
}
