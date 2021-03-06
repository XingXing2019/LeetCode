package com.company;

import java.util.Comparator;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[][] allCellsDistOrder(int R, int C, int r0, int c0) {
        PriorityQueue<int[]> minHeap = new PriorityQueue<>(Comparator.comparingInt(a -> (Math.abs(a[0] - r0) + Math.abs(a[1] - c0))));
        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                minHeap.offer(new int[]{r, c});
            }
        }
        int[][] res = new int[R * C][2];
        int index = 0;
        while (!minHeap.isEmpty())
            res[index++] = minHeap.poll();
        return res;
    }
}
