package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class SeatManager {
    PriorityQueue<Integer> heap;
    public SeatManager(int n) {
        heap = new PriorityQueue<>();
        for (int i = 1; i <= n; i++)
            heap.offer(i);
    }

    public int reserve() {
        return heap.poll();
    }

    public void unreserve(int seatNumber) {
        heap.offer(seatNumber);
    }
}
