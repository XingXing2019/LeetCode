package com.company;

import java.util.Comparator;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[][] points = new int[][]{
                new int[] {1, 3},
                new int[] {-2, 2},
        };
        int K = 1;
        kClosest(points, K);
    }
    public static int[][] kClosest(int[][] points, int K) {
        PriorityQueue<int[]> queue = new PriorityQueue<>((a, b) -> b[0] * b[0] + b[1] * b[1] - a[0] * a[0] - a[1] * a[1]);
        for (int[] point : points){
            queue.offer(point);
            if(queue.size() > K) queue.poll();
        }
        int[][] res = new int[K][];
        return queue.toArray(res);
    }
}
