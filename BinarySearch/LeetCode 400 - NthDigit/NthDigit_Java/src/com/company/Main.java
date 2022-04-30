package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 1000;
        System.out.println(findNthDigit(n));
    }

    public static int findNthDigit(int n) {
        long[] countDigits = new long[10];
        countDigits[0] = 9;
        for (int i = 1; i < countDigits.length; i++)
            countDigits[i] = countDigits[i - 1] * 10;
        for (int i = 1; i < countDigits.length; i++)
            countDigits[i] = countDigits[i] * (i + 1) + countDigits[i - 1];
        long li = 1, hi = n;
        while (li < hi) {
            var mid = li + (hi - li) / 2;
            if (count(countDigits, mid) < n)
                li = mid + 1;
            else
                hi = mid;
        }
        int index = n - (int) count(countDigits, li - 1);
        return Long.toString(li).charAt(index - 1) - '0';
    }

    public static long count(long[] countDigits, long num) {
        int digits = Long.toString(num).length();
        long before = digits - 1 == 0 ? 0 : countDigits[digits - 2];
        long cur = (num - (long) Math.pow(10, digits - 1) + 1) * digits;
        return before + cur;
    }
}
