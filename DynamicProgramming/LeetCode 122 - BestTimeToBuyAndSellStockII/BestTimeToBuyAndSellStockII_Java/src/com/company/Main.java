package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxProfit(int[] prices) {
        int[] hasStock = new int[prices.length];
        int[] noStock = new int[prices.length];
        hasStock[0] = -prices[0];
        for (int i = 1; i < prices.length; i++) {
            hasStock[i] = Math.max(hasStock[i - 1], noStock[i - 1] - prices[i]);
            noStock[i] = Math.max(noStock[i - 1], hasStock[i - 1] + prices[i]);
        }
        return noStock[prices.length - 1];
    }
}
