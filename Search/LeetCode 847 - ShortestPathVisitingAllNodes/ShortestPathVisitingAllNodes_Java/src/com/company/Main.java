package com.company;

import java.util.ArrayDeque;
import java.util.PriorityQueue;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	    int[][] graph = {{1, 2, 3}, {0}, {0}, {0}};
        System.out.println(shortestPathLength(graph));
    }

    public static int shortestPathLength(int[][] graph) {
        int res = Integer.MAX_VALUE, n = graph.length, target = 0;
        for (int i = 0; i < n; i++)
            target += (1 << i);
        for (int i = 0; i < n; i++)
            res = Math.min(res, bfs(graph, i, target));
        return res;
    }

    private static int bfs(int[][] graph, int start, int target) {
        Queue<int[]> queue = new ArrayDeque<>();
        boolean[][] visited = new boolean[graph.length][target + 1];
        queue.offer(new int[] {start, 1 << start, 0});
        visited[start][1 << start] = true;
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            int status = cur[1];
            if (status == target) return cur[2];
            for (int next : graph[cur[0]]) {
                if (visited[next][status | (1 << next)]) continue;
                visited[next][status | (1 << next)] = true;
                queue.offer(new int[] {next, status | (1 << next), cur[2] + 1});
            }
        }
        return Integer.MAX_VALUE;
    }
}
