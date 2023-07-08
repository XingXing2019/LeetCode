package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public long putMarbles(int[] weights, int k) {
        PriorityQueue<Integer> minHeap = new PriorityQueue<>((a, b) -> a - b);
        PriorityQueue<Integer> maxHeap = new PriorityQueue<>((a, b) -> b - a);
        for (int i = 1; i < weights.length; i++) {
            minHeap.offer(weights[i] + weights[i - 1]);
            maxHeap.offer(weights[i] + weights[i - 1]);
            if (minHeap.size() == k)
                minHeap.poll();
            if (maxHeap.size() == k)
                maxHeap.poll();
        }
        long res = 0;
        while (!minHeap.isEmpty())
            res += minHeap.poll() - maxHeap.poll();
        return res;
    }
}
