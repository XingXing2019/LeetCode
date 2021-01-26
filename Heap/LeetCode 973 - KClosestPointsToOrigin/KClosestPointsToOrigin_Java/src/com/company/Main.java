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
        PriorityQueue<Integer> queue = new PriorityQueue<>(Comparator.reverseOrder());
        for (int[] point : points){
            int distance = point[0] * point[0] + point[1] * point[1];
            if(queue.size() < K)
                queue.offer(distance);
            else if (distance < queue.peek()){
                queue.poll();
                queue.offer(distance);
            }
        }
        int[][] res = new int[K][];
        int index = 0;
        for (int[] point : points){
            if(point[0] * point[0] + point[1] * point[1] <= queue.peek())
                res[index++] = point;
        }
        return res;
    }
}
