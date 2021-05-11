package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxScore(int[] cardPoints, int k) {
        for (int i = 1; i < cardPoints.length; i++)
            cardPoints[i] += cardPoints[i - 1];
        if (k == cardPoints.length) return cardPoints[cardPoints.length - 1];
        int min = Integer.MAX_VALUE;
        int len = cardPoints.length - k;
        for (int i = len - 1; i < cardPoints.length; i++) {
            int prefix = i == len - 1 ? 0 : cardPoints[i - len];
            min = Math.min(min, cardPoints[i] - prefix);
        }
        return cardPoints[cardPoints.length - 1] - min;
    }
}
