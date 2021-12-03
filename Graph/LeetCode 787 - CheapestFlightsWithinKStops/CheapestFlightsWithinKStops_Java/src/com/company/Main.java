package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int n = 3, src = 0, dst = 2, k = 0;
        int[][] flight = {{0, 1, 100}, {1, 2, 100}, {0, 2, 500}};
        System.out.println(FindCheapestPrice(n, flight, src, dst, k));
    }

    public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        List<int[]>[] graph = new List[n];
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            graph[i] = new ArrayList<>();
            dp[i] = new int[k + 1];
            if (i != src) Arrays.fill(dp[i], Integer.MAX_VALUE);
        }
        for (int[] flight : flights)
            graph[flight[0]].add(new int[]{flight[1], flight[2]});
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        heap.offer(new int[]{src, 0, k + 1});
        while (!heap.isEmpty()) {
            int[] cur = heap.poll();
            int curCity = cur[0], cost = cur[1], stop = cur[2];
            if (curCity == dst) return cost;
            for (int[] next : graph[curCity]) {
                int nextCity = next[0], price = next[1];
                if (stop != 0 && dp[nextCity][stop - 1] > cost + price) {
                    dp[nextCity][stop - 1] = cost + price;
                    heap.offer(new int[]{nextCity, cost + price, stop - 1});
                }
            }
        }
        return -1;
    }
}
