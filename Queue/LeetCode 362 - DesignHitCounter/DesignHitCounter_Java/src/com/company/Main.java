package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class HitCounter {
    Queue<Integer> queue;
    public HitCounter() {
        queue = new ArrayDeque<>();
    }

    public void hit(int timestamp) {
        queue.offer(timestamp);
    }

    public int getHits(int timestamp) {
        while (!queue.isEmpty() && queue.peek() <= timestamp - 300)
            queue.poll();
        return queue.size();
    }
}