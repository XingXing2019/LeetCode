package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public double maxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        List<double[]>[] graph = new List[n];
        for (int i = 0; i < n; i++)
            graph[i] = new ArrayList<>();
        for (int i = 0; i < edges.length; i++) {
            graph[edges[i][0]].add(new double[] {edges[i][1], succProb[i]});
            graph[edges[i][1]].add(new double[] {edges[i][0], succProb[i]});
        }
        double[] dp = new double[n];
        Queue<double[]> queue = new ArrayDeque<>();
        queue.offer(new double[] {start, 1});
        while (!queue.isEmpty()) {
            double[] cur = queue.poll();
            int curNode = (int)cur[0];
            for (double[] next : graph[curNode]) {
                int nextNode = (int)next[0];
                if (cur[1] * next[1] > dp[nextNode]) {
                    dp[nextNode] = cur[1] * next[1];
                    queue.offer(new double[] {nextNode, cur[1] * next[1]});
                }
            }
        }
        return dp[end];
    }
}
