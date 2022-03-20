package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[][] edges = {{0, 1}, {1, 2}};
        int[] patience = {0, 2, 2};
        System.out.println(networkBecomesIdle(edges, patience));
    }

    public static int networkBecomesIdle(int[][] edges, int[] patience) {
        List<Integer>[] graph = new List[patience.length];
        for (int i = 0; i < graph.length; i++)
            graph[i] = new ArrayList<>();
        for (int[] edge : edges) {
            graph[edge[0]].add(edge[1]);
            graph[edge[1]].add(edge[0]);
        }
        HashSet<Integer> visited = new HashSet<>();
        Queue<int[]> queue = new ArrayDeque<>();
        int[] response = new int[patience.length];
        visited.add(0);
        queue.offer(new int[]{0, 1});
        int res = 0;
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            for (int next : graph[cur[0]]) {
                if (!visited.add(next)) continue;
                queue.offer(new int[] {next, cur[1] + 1});
                response[next] = cur[1] * 2;
            }
        }
        for (int i = 0; i < patience.length; i++) {
            if (patience[i] >= response[i])
                res = Math.max(res, response[i] + 1);
            else {
                int time = (int) (Math.ceil((double) response[i] / patience[i]) - 1) * patience[i] + response[i];
                res = Math.max(res, time + 1);
            }
        }
        return res;
    }
}
