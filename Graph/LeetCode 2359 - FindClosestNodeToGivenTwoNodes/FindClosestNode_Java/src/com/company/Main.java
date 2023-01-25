package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[] edges = {2, 0, 0};
        int node1 = 2, node2 = 0;
        System.out.println(closestMeetingNode(edges, node1, node2));
    }

    public static int closestMeetingNode(int[] edges, int node1, int node2) {
        List<Integer>[] graph = new List[edges.length];
        for (int i = 0; i < edges.length; i++)
            graph[i] = new ArrayList<>();
        for (int i = 0; i < edges.length; i++) {
            if (edges[i] == -1) continue;
            graph[i].add(edges[i]);
        }
        Map<Integer, Integer> dis1 = new HashMap<>();
        Map<Integer, Integer> dis2 = new HashMap<>();
        bfs(graph, node1, dis1);
        bfs(graph, node2, dis2);
        int res = edges.length, min = Integer.MAX_VALUE;
        for (int node : dis1.keySet()) {
            if (!dis2.containsKey(node)) continue;
            int max = Math.max(dis1.get(node), dis2.get(node));
            if (min >= max) {
                if (min == max && node < res) {
                    res = node;
                } else if (min > max) {
                    min = max;
                    res = node;
                }
            }
        }
        return res == edges.length ? -1 : res;
    }

    private static void bfs(List<Integer>[] graph, int start, Map<Integer, Integer> dis) {
        Queue<Integer> queue = new ArrayDeque<>();
        HashSet<Integer> visited = new HashSet<>();
        queue.offer(start);
        visited.add(start);
        int step = 0;
        while (!queue.isEmpty()) {
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                int cur = queue.poll();
                dis.put(cur, step);
                for (int next : graph[cur]) {
                    if (!visited.add(next)) continue;
                    queue.offer(next);
                }
            }
            step++;
        }
    }
}
