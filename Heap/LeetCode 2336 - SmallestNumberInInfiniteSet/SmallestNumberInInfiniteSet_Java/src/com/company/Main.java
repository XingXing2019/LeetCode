package com.company;

import java.util.HashSet;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class SmallestInfiniteSet {
    HashSet<Integer> set;
    PriorityQueue<Integer> heap;
    public SmallestInfiniteSet() {
        set = new HashSet<>();
        heap = new PriorityQueue<>();
        for (int i = 1; i <= 1000; i++) {
            set.add(i);
            heap.offer(i);
        }
    }

    public int popSmallest() {
        var min = heap.poll();
        set.remove(min);
        return min;
    }

    public void addBack(int num) {
        if (set.add(num)) {
            heap.offer(num);
        }
    }
}
