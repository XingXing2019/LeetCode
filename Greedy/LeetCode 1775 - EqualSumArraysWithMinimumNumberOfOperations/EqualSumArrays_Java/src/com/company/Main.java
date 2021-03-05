package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] nums1 = {1, 2, 3, 4, 5, 6};
        int[] nums2 = {1, 1, 2, 2, 2, 2};
        minOperations(nums1, nums2);
    }

    public static int minOperations(int[] nums1, int[] nums2) {
        int sum1 = Arrays.stream(nums1).sum(), sum2 = Arrays.stream(nums2).sum(), diff = Math.abs(sum1 - sum2);
        return sum1 > sum2 ? getMinOperations(nums1, nums2, diff) : getMinOperations(nums2, nums1, diff);
    }

    public static int getMinOperations(int[] nums1, int[] nums2, int diff) {
        PriorityQueue<Integer> maxHeap = new PriorityQueue<>((a, b) -> b - a);
        PriorityQueue<Integer> minHeap = new PriorityQueue<>();
        for (int num : nums1) maxHeap.offer(num);
        for (int num : nums2) minHeap.offer(num);
        int res = 0;
        while (!maxHeap.isEmpty() && !minHeap.isEmpty() && diff > 0) {
            if (maxHeap.peek() - 1 > 6 - minHeap.peek())
                diff -= Math.min(diff, maxHeap.poll() - 1);
            else
                diff -= Math.min(diff, 6 - minHeap.poll());
            res++;
        }
        while (!maxHeap.isEmpty() && diff > 0) {
            diff -= Math.min(diff, maxHeap.poll() - 1);
            res++;
        }
        while (!minHeap.isEmpty() && diff > 0) {
            diff -= Math.min(diff, 6 - minHeap.poll());
            res++;
        }
        return diff == 0 ? res : -1;
    }
}
