package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] target = {2,900000002};
        isPossible(target);
    }

    public static boolean isPossible(int[] target) {
        long sum = 0;
        PriorityQueue<Integer> maxHeap = new PriorityQueue<>((a, b) -> b - a);
        for (int num : target) {
            sum += num;
            maxHeap.offer(num);
        }
        sum -= maxHeap.peek();
        while (maxHeap.peek() != 1) {
            int max = maxHeap.poll();
            if(sum == 0 || max <= sum) return false;
            max %= sum;
            if (max < maxHeap.peek())
                sum = sum - maxHeap.peek() + max;
            maxHeap.offer(max);
        }
        return true;
    }
}
