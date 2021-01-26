package com.company;

import java.util.Comparator;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	    int[] stones = {2,2};
	    System.out.print(lastStoneWeight(stones));
    }

    public static int lastStoneWeight(int[] stones) {
        PriorityQueue<Integer> queue = new PriorityQueue<>(Comparator.reverseOrder());
        for (int stone : stones)
            queue.offer(stone);
        while(queue.size() > 1){
            int stone1 = queue.poll();
            int stone2 = queue.poll();
            if(stone1 != stone2)
                queue.offer(stone1 - stone2);
        }
        return queue.size() == 0 ? 0 : queue.poll();
    }
}
