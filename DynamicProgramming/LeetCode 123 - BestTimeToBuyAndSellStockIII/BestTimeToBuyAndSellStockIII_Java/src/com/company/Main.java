package com.company;

public class Main {

    public static void main(String[] args) {
        int[] prices = {1, 2, 3, 4, 5};
        System.out.println(maxProfit(prices));
    }

    public static int maxProfit(int[] prices) {
        int[] leftMax = new int[prices.length];
        int[] rightMax = new int[prices.length];
        int min = prices[0], max = prices[prices.length - 1];
        int leftProfit = 0, rightProfit = 0, res = 0;
        for (int i = 0; i < prices.length; i++) {
            leftProfit = Math.max(leftProfit, prices[i] - min);
            leftMax[i] = leftProfit;
            min = Math.min(min, prices[i]);
            rightProfit = Math.max(rightProfit, max - prices[prices.length - i - 1]);
            rightMax[prices.length - i - 1] = rightProfit;
            max = Math.max(max, prices[prices.length - i - 1]);
        }
        for (int i = 0; i < prices.length; i++)
            res = Math.max(res, leftMax[i] + rightMax[i]);
        return res;
    }
}
