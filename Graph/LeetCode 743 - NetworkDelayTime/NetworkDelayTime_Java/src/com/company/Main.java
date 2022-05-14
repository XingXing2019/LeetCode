package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	    int[][] times = {{2, 1, 1}, {2, 3, 1}, {3, 4, 1}};
	    int n = 4, k = 2;
        System.out.println(networkDelayTime(times, n, k));
    }

    public static int networkDelayTime(int[][] times, int n, int k) {
        List<int[]>[] graph = new List[n + 1];
        int[] dp = new int[n + 1];
        for (int i = 0; i < n + 1; i++) {
            graph[i] = new ArrayList<>();
            dp[i] = Integer.MAX_VALUE;
        }
        for (int[] time : times)
            graph[time[0]].add(new int[] {time[1], time[2]});
        Queue<int[]> queue = new ArrayDeque<>();
        dp[k] = 0;
        queue.offer(new int[] {k, 0});
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            for (int[] next : graph[cur[0]]) {
                if (dp[next[0]] <= cur[1] + next[1]) continue;
                dp[next[0]] = cur[1] + next[1];
                queue.offer(new int[] {next[0], dp[next[0]]});
            }
        }
        int res = -1;
        for (int i = 1; i < dp.length; i++) {
            if (dp[i] == Integer.MAX_VALUE) return -1;
            res = Math.max(res, dp[i]);
        }
        return res;
    }
}
