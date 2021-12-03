package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minCost(int maxTime, int[][] edges, int[] passingFees) {
        int n = passingFees.length;
        List<int[]>[] graph = new List[n];
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            graph[i] = new ArrayList<>();
            dp[i] = new int[maxTime + 1];
            if (i != 0) Arrays.fill(dp[i], Integer.MAX_VALUE);
        }
        for (int[] e : edges) {
            graph[e[0]].add(new int[]{e[1], e[2]});
            graph[e[1]].add(new int[]{e[0], e[2]});
        }
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        heap.offer(new int[]{0, passingFees[0], maxTime});
        while (!heap.isEmpty()) {
            int[] cur = heap.poll();
            int curCity = cur[0], cost = cur[1], timeLeft = cur[2];
            if (curCity == n - 1) return cost;
            for (int[] next : graph[curCity]) {
                int nextCity = next[0], time = next[1];
                if (timeLeft - time >= 0 && dp[nextCity][timeLeft - time] > cost + passingFees[nextCity]) {
                    dp[nextCity][timeLeft - time] = cost + passingFees[nextCity];
                    heap.offer(new int[]{nextCity, cost + passingFees[nextCity], timeLeft - time});
                }
            }
        }
        return -1;
    }
}
