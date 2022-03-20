package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int catMouseGame(int[][] graph) {
        int[][][] dp = new int[graph.length * 4][graph.length][graph.length];
        for (int i = 0; i < dp.length; i++) {
            for (int j = 0; j < dp[i].length; j++) {
                Arrays.fill(dp[i][j], -1);
            }
        }
        return dfs(graph, dp, 0, 1, 2);
    }

    public int dfs(int[][] graph, int[][][] dp, int turn, int mouse, int cat) {
        if (turn >= graph.length * 4) return 0;
        if (mouse == 0) return 1;
        if (cat == mouse) return 2;
        if (dp[turn][mouse][cat] != -1) return dp[turn][mouse][cat];
        if (turn % 2 == 0) {
            var catWin = true;
            for (var nextMouse : graph[mouse]) {
                var next = dfs(graph, dp, turn + 1, nextMouse, cat);
                if (next == 1)
                    return dp[turn][mouse][cat] = 1;
                else if (next != 2)
                    catWin = false;
            }
            dp[turn][mouse][cat] = catWin ? 2 : 0;
        } else {
            var mouseWin = true;
            for (var nextCat : graph[cat]) {
                if (nextCat == 0) continue;
                var next = dfs(graph, dp, turn + 1, mouse, nextCat);
                if (next == 2)
                    return dp[turn][mouse][cat] = 2;
                else if (next != 1)
                    mouseWin = false;
            }
            dp[turn][mouse][cat] = mouseWin ? 1 : 0;
        }
        return dp[turn][mouse][cat];
    }
}
