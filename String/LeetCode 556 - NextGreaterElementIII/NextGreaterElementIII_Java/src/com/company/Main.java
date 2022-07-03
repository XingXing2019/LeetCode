package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int n = 2147483486;
        System.out.println(nextGreaterElement(n));
    }

    public static int nextGreaterElement(int n) {
        long res = Long.MAX_VALUE;
        for (int i = Integer.toString(n).length() - 1; i >= 0; i--)
            res = Math.min(res, createNum(n, i));
        return res > Integer.MAX_VALUE ? -1 : (int) res;
    }

    public static long createNum(int n, int index) {
        int[] digits = new int[Integer.toString(n).length()];
        for (int i = digits.length - 1; i >= 0; i--) {
            digits[i] = n % 10;
            n /= 10;
        }
        for (int i = index - 1; i >= 0; i--) {
            if (digits[i] >= digits[index]) continue;
            int temp = digits[i];
            digits[i] = digits[index];
            digits[index] = temp;
            Arrays.sort(digits, i + 1, digits.length);
            long res = 0;
            for (int j = 0; j < digits.length; j++)
                res = res * 10 + digits[j];
            return res;
        }
        return Long.MAX_VALUE;
    }
}
