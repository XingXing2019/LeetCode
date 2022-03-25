package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int trailingZeroes(int n) {
        int res = 0, pow = 5;
        while (n >= pow) {
            res += n / pow;
            pow *= 5;
        }
        return res;
    }
}
