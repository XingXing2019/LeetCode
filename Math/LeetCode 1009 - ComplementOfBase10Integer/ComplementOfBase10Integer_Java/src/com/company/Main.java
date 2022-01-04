package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 5;
        System.out.println(bitwiseComplement(n));
    }

    public static int bitwiseComplement(int n) {
        if (n == 0) return 1;
        int res = ~n, count = 0;
        while (n != 0) {
            count++;
            n >>= 1;
        }
        for (int i = 0; i < 32 - count; i++)
            res <<= 1;
        for (int i = 0; i < 32 - count; i++)
            res >>= 1;
        return res;
    }
}
