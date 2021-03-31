package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int minimumCost(int N, int[][] connections) {
        List<int[]>[] graph = new List[N + 1];
        for (int i = 0; i < graph.length; i++)
            graph[i] = new ArrayList<>();
        for (int[] c : connections){
            graph[c[0]].add(new int[]{c[1], c[2]});
            graph[c[1]].add(new int[]{c[0], c[2]});
        }
        PriorityQueue<int[]> heap = new PriorityQueue<>(Comparator.comparingInt(a -> a[0]));
        heap.offer(new int[]{0, 1});
        HashSet<Integer> visited = new HashSet<>();
        int res = 0;
        while (!heap.isEmpty()){
            int[] cur = heap.poll();
            if(!visited.add(cur[1])) continue;
            res += cur[0];
            for (int[] next : graph[cur[1]])
                heap.offer(new int[]{next[1], next[0]});
        }
        return visited.size() == N ? res : -1;
    }
}
