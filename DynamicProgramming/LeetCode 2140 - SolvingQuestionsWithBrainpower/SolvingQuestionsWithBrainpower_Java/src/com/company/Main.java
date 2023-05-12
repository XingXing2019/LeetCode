package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] questions = {{1, 1}, {2, 2}, {3, 3}, {4, 4}, {5, 5}};
        System.out.println(mostPoints(questions));
    }

    public static long mostPoints(int[][] questions) {
        long[][] dp = new long[questions.length][2];
        dp[dp.length - 1] = new long[] {questions[questions.length - 1][0], 0};
        for (int i = dp.length - 2; i >= 0; i--) {
            int index = i + questions[i][1] + 1;
            dp[i][0] = questions[i][0] + (index < dp.length ? Math.max(dp[index][0], dp[index][1]) : 0);
            dp[i][1] = Math.max(dp[i + 1][0], dp[i + 1][1]);
        }
        return Math.max(dp[0][0], dp[0][1]);
    }
}
