package com.company;

import java.util.Arrays;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int connectSticks(int[] sticks) {
        PriorityQueue<Integer> heap = new PriorityQueue<>();
        for (int s : sticks)
            heap.offer(s);
        int res = 0;
        while (heap.size() > 1){
            int cost = heap.poll() + heap.poll();
            res += cost;
            heap.offer(cost);
        }
        return res;
    }
}
