package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] arr = {1, 2, 3, 5};
        int k = 4;
        System.out.println(kthSmallestPrimeFraction(arr, k));
    }

    public static int[] kthSmallestPrimeFraction(int[] arr, int k) {
        PriorityQueue<double[]> minHeap = new PriorityQueue<>((a, b) -> a[0] > b[0] ? 1 : -1);
        for (int i = arr.length - 1; i >= 1; i--) {
            double factor = (double) arr[0] / arr[i];
            minHeap.offer(new double[]{factor, 0, i});
        }
        for (int i = 0; i < k - 1; i++) {
            double[] min = minHeap.poll();
            if (min[1] + 1 < min[2]) {
                int index1 = (int) min[1] + 1, index2 = (int) min[2];
                double factor = (double)arr[index1] / arr[index2];
                minHeap.offer(new double[]{factor, min[1] + 1, min[2]});
            }
        }
        double[] res = minHeap.poll();
        return new int[]{arr[(int) res[1]], arr[(int) res[2]]};
    }
}
