package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	    int[] costs = {5,3,2,7,1};
	    int k = 5, candidates = 2;
        System.out.println(totalCost(costs, k, candidates));
    }

    public static long totalCost(int[] costs, int k, int candidates) {
        if (costs.length == 1) return costs[0];
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        int li = 0, hi = costs.length - 1;
        while (li < hi && candidates != 0) {
            heap.offer(new int[] {costs[li], li++, 0});
            heap.offer(new int[] {costs[hi], hi--, 1});
            candidates--;
        }
        long res = 0;
        for (int i = 0; i < k; i++) {
            var min = heap.poll();
            res += min[0];
            if (min[2] == 0 && hi >= li)
                heap.offer(new int[] {costs[li], li++, 0});
            else if (min[2] == 1 && hi >= li)
                heap.offer(new int[] {costs[hi], hi--,1});
        }
        return res;
    }
}
