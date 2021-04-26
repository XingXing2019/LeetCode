package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int furthestBuilding(int[] heights, int bricks, int ladders) {
        PriorityQueue<Integer> heap = new PriorityQueue<>();
        for (int i = 1; i < heights.length; i++) {
            if(heights[i] > heights[i - 1]){
                int diff = heights[i] - heights[i - 1];
                heap.offer(diff);
                if(heap.size() > ladders)
                    bricks -= heap.poll();
                if(bricks < 0)
                    return i - 1;
            }
        }
        return heights.length - 1;
    }
}
