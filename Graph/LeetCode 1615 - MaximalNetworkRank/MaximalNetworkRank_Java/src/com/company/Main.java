package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	    int n = 4;
	    int[][] roads = {{0, 1}, {0, 3}, {1, 2}, {1, 3}};
        System.out.println(maximalNetworkRank(n, roads));
    }

    public static int maximalNetworkRank(int n, int[][] roads) {
        HashSet<Integer>[] graph = new HashSet[n];
        for (int i = 0; i < n; i++)
            graph[i] = new HashSet<>();
        for (int[] road : roads) {
            graph[road[0]].add(road[1]);
            graph[road[1]].add(road[0]);
        }
        int res = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i == j) continue;
                var count = graph[i].size() + (graph[j].contains(i) ? graph[j].size() - 1 : graph[j].size());
                res = Math.max(res, count);
            }
        }
        return res;
    }
}
