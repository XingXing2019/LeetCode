package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int countHousePlacements(int n) {
        long num1 = 1, num2 = 2, mod = 1_000_000_000 + 7;
        for (int i = 1; i < n; i++) {
            long temp = (num1 + num2) % mod;
            num1 = num2;
            num2 = temp;
        }
        return (int) (num2 * num2 % mod);
    }
}
