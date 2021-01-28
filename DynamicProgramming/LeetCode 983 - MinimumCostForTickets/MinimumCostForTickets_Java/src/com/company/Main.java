package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int mincostTickets(int[] days, int[] costs) {
        int[] dp = new int[days[days.length - 1] + 1];
        for (int day : days)
            dp[day] = 1;
        for (int i = 1; i < dp.length; i++) {
            if(dp[i] == 1){
                int option1 = i >= 1 ? dp[i - 1] + costs[0] : costs[0];
                int option2 = i >= 7 ? dp[i - 7] + costs[1] : costs[1];
                int option3 = i >= 30 ? dp[i - 30] + costs[2] : costs[2];
                dp[i] = Math.min(option1, Math.min(option2, option3));
            }
            else
                dp[i] = dp[i - 1];
        }
        return dp[dp.length - 1];
    }
}
