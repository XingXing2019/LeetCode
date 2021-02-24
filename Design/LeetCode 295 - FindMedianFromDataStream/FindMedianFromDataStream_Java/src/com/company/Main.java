package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

public class MedianFinder {

    PriorityQueue<Integer> minHeap;
    PriorityQueue<Integer> maxHeap;
    public MedianFinder() {
        minHeap = new PriorityQueue<>();
        maxHeap = new PriorityQueue<>((a, b) -> b - a);
    }

    public void addNum(int num) {
        maxHeap.offer(num);
        minHeap.offer(maxHeap.poll());
        if(maxHeap.size() < minHeap.size())
            maxHeap.offer(minHeap.poll());
    }

    public double findMedian() {
        return (maxHeap.size() + minHeap.size()) % 2 == 0 ? ((double) minHeap.peek() + maxHeap.peek()) / 2 : maxHeap.peek();
    }
}
