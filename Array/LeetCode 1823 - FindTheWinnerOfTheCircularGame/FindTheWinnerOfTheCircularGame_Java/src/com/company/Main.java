package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int findTheWinner(int n, int k) {
        Queue<Integer> queue = new ArrayDeque<>();
        for (int i = 1; i <= n; i++)
            queue.offer(i);
        while (queue.size() != 1) {
            var time = k % queue.size() == 0 ? queue.size() : k % queue.size();
            for (int i = 0; i < time - 1; i++)
                queue.offer(queue.poll());
            queue.poll();
        }
        return queue.peek();
    }
}
