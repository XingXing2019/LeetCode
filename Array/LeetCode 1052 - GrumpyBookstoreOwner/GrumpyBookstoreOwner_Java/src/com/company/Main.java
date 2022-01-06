package com.company;

public class Main {

    public static void main(String[] args) {
        int[] customer = {5, 8}, grumpy = {0, 1};
        int minutes = 1;
        System.out.println(maxSatisfied(customer, grumpy, minutes));
    }

    public static int maxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int sum = 0, li = 0, hi = minutes - 1, res = 0;
        for (int i = 0; i < customers.length; i++) {
            if (grumpy[i] == 0 || i <= hi)
                sum += customers[i];
        }
        while (hi < customers.length - 1) {
            res = Math.max(res, sum);
            if (grumpy[++hi] == 1)
                sum += customers[hi];
            if (grumpy[li++] == 1)
                sum -= customers[li - 1];
        }
        return Math.max(res, sum);
    }
}
