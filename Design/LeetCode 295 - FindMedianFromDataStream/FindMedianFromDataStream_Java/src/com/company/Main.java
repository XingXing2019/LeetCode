package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

public class MedianFinder_Heap {

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

public class MedianFinder_BinarySearch {

    List<Integer> nums;
    public MedianFinder() {
        nums = new ArrayList<>();
    }

    public void addNum(int num) {
        int index = Collections.binarySearch(nums, num);
        if(index < 0) index = ~index;
        nums.add(index, num);
    }

    public double findMedian() {
        return nums.size() % 2 == 0 ? ((double) nums.get(nums.size() / 2) + nums.get(nums.size() / 2 - 1)) / 2 : nums.get(nums.size() / 2);
    }
}
