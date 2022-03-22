package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int n = 3;
        int[][] relations = {{1, 3}, {2, 3}};
        int[] time = {3, 2, 5};
        System.out.println(minimumTime(n, relations, time));
    }

    public static int minimumTime(int n, int[][] relations, int[] time) {
        int[] dp = new int[n + 1];
        int[] degree = new int[n + 1];
        int res = 0;
        List<Integer>[] graph = new List[n + 1];
        for (int i = 0; i < graph.length; i++)
            graph[i] = new ArrayList<>();
        for (int[] r : relations) {
            graph[r[0]].add(r[1]);
            degree[r[1]]++;
        }
        Queue<Integer> queue = new ArrayDeque<>();
        for (int i = 1; i < degree.length; i++) {
            if (degree[i] != 0) continue;
            queue.offer(i);
            dp[i] = time[i - 1];
            res = Math.max(res, dp[i]);
        }
        while (!queue.isEmpty()) {
            int cur = queue.poll();
            for (int next : graph[cur]) {
                degree[next]--;
                if (degree[next] == 0)
                    queue.offer(next);
                dp[next] = Math.max(dp[next], dp[cur] + time[next - 1]);
                res = Math.max(res, dp[next]);
            }
        }
        return res;
    }
}
