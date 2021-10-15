package com.company;

public class Main {

    public static void main(String[] args) {
        int[] prices = {1, 2, 3, 0, 2};
        System.out.println(maxProfit(prices));
    }

    public static int maxProfit(int[] prices) {
        int[] hasStock = new int[prices.length];
        int[] noStock = new int[prices.length];
        hasStock[0] = -prices[0];
        for (int i = 1; i < prices.length; i++) {
            hasStock[i] = Math.max(hasStock[i - 1], -prices[i] + (i == 1 ? 0 : noStock[i - 2]));
            noStock[i] = Math.max(noStock[i - 1], hasStock[i - 1] + prices[i]);
        }
        return noStock[prices.length - 1];
    }
}
