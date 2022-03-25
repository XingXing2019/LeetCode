package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int twoCitySchedCost(int[][] costs) {
        int res = 0;
        for (int[] cost : costs)
            res += cost[1];
        Arrays.sort(costs, (a, b) -> (a[0] - a[1]) - (b[0] - b[1]));
        for (int i = 0; i < costs.length / 2; i++) {
            res -= costs[i][1];
            res += costs[i][0];
        }
        return res;
    }
}
