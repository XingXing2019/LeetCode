package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	    int n = 4;
	    int[][] edges = {{1, 0}, {1, 2}, {1, 3}};
        System.out.println(findMinHeightTrees(n, edges));
    }

    public static List<Integer> findMinHeightTrees(int n, int[][] edges) {
        if (n == 1) return new ArrayList<>(){{add(0);}};
        List<Integer> res = new ArrayList<>();
        List<Integer>[] graph = new List[n];
        for (int i = 0; i < n; i++)
            graph[i] = new ArrayList<>();
        int[] degree = new int[n];
        for (int[] edge : edges) {
            graph[edge[0]].add(edge[1]);
            graph[edge[1]].add(edge[0]);
            degree[edge[0]]++;
            degree[edge[1]]++;
        }
        Queue<Integer> queue = new ArrayDeque<>();
        for (int i = 0; i < n; i++) {
            if (degree[i] != 1) continue;
            queue.offer(i);
        }
        while (!queue.isEmpty()) {
            int count = queue.size();
            res.clear();
            for (int i = 0; i < count; i++) {
                int cur = queue.poll();
                res.add(cur);
                for (int next : graph[cur]) {
                    degree[next]--;
                    if (degree[next] != 1) continue;
                    queue.offer(next);
                }
            }
        }
        return res;
    }
}
