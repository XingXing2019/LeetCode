package com.company;

import java.util.Comparator;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	    int k = 3;
	    int[] nums = {4, 5, 8, 2};
	    KthLargest obj = new KthLargest(k, nums);
	    obj.add(3);
	    obj.add(5);
	    obj.add(10);
	    obj.add(9);
	    obj.add(4);
    }
}

class KthLargest {

    PriorityQueue<Integer> queue;
    int size;
    public KthLargest(int k, int[] nums) {
        queue = new PriorityQueue<>();
        size = k;
        for(int num : nums)
            queue.add(num);
        while (queue.size() > k)
            queue.poll();
    }

    public int add(int val) {
        if(queue.size() < size)
            queue.add(val);
        else if(val > queue.peek()){
            queue.poll();
            queue.add(val);
        }
        return queue.peek();
    }
}
