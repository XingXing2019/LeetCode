package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int n = 4, discount = 4;
        int[][] highways = {
                {1, 2, 7},
                {3, 2, 5},
                {0, 1, 6},
                {3, 0, 20}
        };
        System.out.println(minimumCost(n, highways, discount));
    }

    public static int minimumCost(int n, int[][] highways, int discounts) {
        List<int[]>[] graph = new List[n];
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            graph[i] = new ArrayList<>();
            dp[i] = new int[discounts + 1];
            if (i != 0) Arrays.fill(dp[i], Integer.MAX_VALUE);
        }
        for (int[] highway : highways) {
            graph[highway[0]].add(new int[]{highway[1], highway[2]});
            graph[highway[1]].add(new int[]{highway[0], highway[2]});
        }
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        heap.offer(new int[]{0, 0, discounts});
        while (!heap.isEmpty()) {
            int[] cur = heap.poll();
            int curCity = cur[0], cost = cur[1], dis = cur[2];
            if (curCity == n - 1) return cost;
            for (int[] next : graph[curCity]) {
                int nextCity = next[0], toll = next[1];
                if (dis != 0 && dp[nextCity][dis - 1] > cost + toll / 2) {
                    heap.offer(new int[]{nextCity, cost + toll / 2, dis - 1});
                    dp[nextCity][dis - 1] = cost + toll / 2;
                }
                if (dp[nextCity][dis] > cost + toll) {
                    heap.offer(new int[]{nextCity, cost + toll, dis});
                    dp[nextCity][dis] = cost + toll;
                }
            }
        }
        return -1;
    }
}
