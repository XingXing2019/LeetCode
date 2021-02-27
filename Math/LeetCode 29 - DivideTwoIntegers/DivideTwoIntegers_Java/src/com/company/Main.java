package com.company;

public class Main {

    public static void main(String[] args) {
        int divident = -2147483648, divisor = 1;
        System.out.println(divide(divident, divisor));
    }

    public static int divide(int dividend, int divisor) {
        if (dividend == 0) return 0;
        boolean isNegative = dividend < 0 && divisor > 0 || dividend > 0 && divisor < 0;
        long longDividend = Math.abs((long) dividend), longDivisor = Math.abs((long) divisor);
        if (longDividend < longDivisor) return 0;
        long li = 1, hi = longDividend;
        while (li <= hi) {
            long mid = li + ((hi - li) >> 1);
            if (mid * longDivisor > longDividend) hi = mid - 1;
            else li = mid + 1;
        }
        if (!isNegative && (hi > Integer.MAX_VALUE || hi <= Integer.MIN_VALUE)) return Integer.MAX_VALUE;
        return isNegative ? -(int) hi : (int) hi;
    }
}
