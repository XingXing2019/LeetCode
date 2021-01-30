package com.company;

import java.util.Arrays;
import java.util.Comparator;
import java.util.HashSet;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] nums = {399,908,648};
        System.out.println(minimumDeviation(nums));
    }

    public static int minimumDeviation(int[] nums) {
        PriorityQueue<Integer> maxHeap = new PriorityQueue<>(Comparator.reverseOrder());
        PriorityQueue<Integer> minHeap = new PriorityQueue<>();
        Arrays.sort(nums);
        int min = nums[0], max = nums[nums.length - 1];
        int res = max - min;
        for (int i = 0; i < nums.length; i++) {
            if(!minHeap.isEmpty()){
                min = Math.min(nums[i], minHeap.peek());
                max = Math.max(nums[nums.length - 1], maxHeap.peek());
            }
            maxHeap.offer(nums[i] % 2 != 0 ? nums[i] * 2 : nums[i]);
            minHeap.offer(nums[i] % 2 != 0 ? nums[i] * 2 : nums[i]);
            res = Math.min(res, max - min);
        }
        while (maxHeap.peek() % 2 == 0) {
            int temp = maxHeap.poll();
            maxHeap.offer(temp / 2);
            minHeap.offer(temp / 2);
            res = Math.min(res, maxHeap.peek() - minHeap.peek());
        }
        return res;
    }
}
