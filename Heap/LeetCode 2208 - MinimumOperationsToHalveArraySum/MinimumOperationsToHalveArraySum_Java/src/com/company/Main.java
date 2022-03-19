package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 1, 1};
        System.out.println(halveArray(nums));
    }

    public static int halveArray(int[] nums) {
        PriorityQueue<Double> heap = new PriorityQueue<>((a, b) -> b.compareTo(a));
        double sum = 0;
        for (int num : nums) {
            heap.offer((double) num);
            sum += num;
        }
        double target = sum / 2;
        int res = 0;
        while (sum > target) {
            double max = heap.poll();
            sum = sum - max + max / 2;
            heap.offer(max / 2);
            res++;
        }
        return res;
    }
}
