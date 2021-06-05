package com.company;

import java.util.Arrays;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxPerformance(int n, int[] speed, int[] efficiency, int k) {
        int[][] engineers = new int[n][];
        for (int i = 0; i < n; i++)
            engineers[i] = new int[]{speed[i], efficiency[i]};
        Arrays.sort(engineers, (a, b) -> b[1] - a[1]);
        long res = 0, sum = 0, mod = 1_000_000_000 + 7;
        PriorityQueue<Integer> heap = new PriorityQueue<>();
        for (int[] engineer : engineers) {
            heap.offer(engineer[0]);
            sum += engineer[0];
            if (heap.size() > k)
                sum -= heap.poll();
            res = Math.max(res, sum * engineer[1]);
        }
        return (int) (res % mod);
    }
}
