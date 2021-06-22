package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int n = 4, source = 0, destination = 3;
        int[][] edges = {{0, 1}, {0, 3}, {1, 2}, {2, 1}};
        System.out.println(leadsToDestination(n, edges, source, destination));
    }

    public static boolean leadsToDestination(int n, int[][] edges, int source, int destination) {
        HashSet<Integer>[] graph = new HashSet[n];
        HashSet<Integer>[] path = new HashSet[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new HashSet<>();
            path[i] = new HashSet<>();
        }
        for (int[] edge : edges)
            graph[edge[0]].add(edge[1]);
        boolean[] visited = new boolean[n];
        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(source);
        visited[source] = true;
        path[source].add(source);
        while (!queue.isEmpty()) {
            int cur = queue.poll();
            if (cur != destination && graph[cur].size() == 0 || (cur == destination && graph[cur].size() != 0))
                return false;
            for (int next : graph[cur]) {
                if (path[cur].contains(next) || cur == next) return false;
                if (!visited[next]) {
                    queue.offer(next);
                    visited[next] = true;
                }
                path[next].add(cur);
            }
        }
        return true;
    }
}
