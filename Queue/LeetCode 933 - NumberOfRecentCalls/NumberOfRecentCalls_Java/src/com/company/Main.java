package com.company;

import java.util.ArrayDeque;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class RecentCounter {

    ArrayDeque<Integer> queue;
    public RecentCounter() {
        queue = new ArrayDeque<>();
    }

    public int ping(int t) {
        while (!queue.isEmpty() && queue.peek() < t - 3000)
            queue.poll();
        queue.offer(t);
        return queue.size();
    }
}
