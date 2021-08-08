package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minStoneSum(int[] piles, int k) {
        var heap = new PriorityQueue<Integer>((a, b) -> b - a);
        for (var pile : piles)
            heap.offer(pile);
        for (int i = 0; i < k; i++) {
            var max = heap.poll();
            heap.offer(max - max / 2);
        }
        int res = 0;
        while (!heap.isEmpty())
            res += heap.poll();
        return res;
    }
}
