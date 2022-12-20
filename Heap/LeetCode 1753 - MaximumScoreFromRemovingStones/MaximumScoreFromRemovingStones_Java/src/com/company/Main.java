package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maximumScore(int a, int b, int c) {
        PriorityQueue<Integer> heap = new PriorityQueue<>((x, y) -> y - x);
        heap.offer(a);
        heap.offer(b);
        heap.offer(c);
        int res = 0;
        while (heap.size() > 1) {
            var x = heap.poll();
            var y = heap.poll();
            x--;
            y--;
            res++;
            if (x != 0) heap.offer(x);
            if (y != 0) heap.offer(y);
        }
        return res;
    }
}
