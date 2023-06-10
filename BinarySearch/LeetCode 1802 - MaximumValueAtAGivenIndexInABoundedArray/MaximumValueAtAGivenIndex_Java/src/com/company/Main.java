package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 6, index = 1, maxSum = 10;
        System.out.println(maxValue(n, index, maxSum));
    }

    public static int maxValue(int n, int index, int maxSum) {
        int li = 1, hi = maxSum;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (getSum(index, n, mid) <= maxSum)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return hi;
    }

    public static long getSum(int index, int n, int num){
        long prefix = index < num ? (long)(num - index + num - 1) * index / 2 : (long)num * (num - 1) / 2 + index - num + 1;
        long suffix = (n - 1 - index) < num ? (long)(2 * num - n + index) * (n - 1 - index) / 2 : (long) num * (num - 1) / 2 + (n - index - num);
        return prefix + num + suffix;
    }
}
