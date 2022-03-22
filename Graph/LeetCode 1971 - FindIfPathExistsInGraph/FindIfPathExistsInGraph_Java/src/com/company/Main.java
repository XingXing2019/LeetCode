package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean validPath(int n, int[][] edges, int source, int destination) {
        List<Integer>[] graph = new ArrayList[n];
        for (int i = 0; i < n; i++)
            graph[i] = new ArrayList<>();
        for (int[] edge : edges) {
            graph[edge[0]].add(edge[1]);
            graph[edge[1]].add(edge[0]);
        }
        Queue<Integer> queue = new ArrayDeque<>();
        HashSet<Integer> visited = new HashSet<>();
        queue.offer(source);
        visited.add(source);
        while (!queue.isEmpty()) {
            int cur = queue.poll();
            if (cur == destination) return true;
            for (int next : graph[cur]) {
                if (!visited.add(next)) continue;
                queue.offer(next);
            }
        }
        return false;
    }
}
