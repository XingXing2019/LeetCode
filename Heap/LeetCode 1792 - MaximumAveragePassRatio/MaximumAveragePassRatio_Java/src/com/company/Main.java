package com.company;

import java.util.Comparator;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[][] classes = {{1, 2}, {3, 5}, {2, 2}};
        int extraStudents = 2;
        System.out.println(maxAverageRatio(classes, extraStudents));
    }

    public static double maxAverageRatio(int[][] classes, int extraStudents) {
        PriorityQueue<int[]> maxHeap = new PriorityQueue<>((a, b) -> compare(a, b));
        for (int[] c : classes)
            maxHeap.offer(c);
        for (int i = 0; i < extraStudents; i++) {
            int[] c = maxHeap.poll();
            c[0]++;
            c[1]++;
            maxHeap.offer(c);
        }
        double sum = 0, count = maxHeap.size();
        while (!maxHeap.isEmpty()) {
            int[] c = maxHeap.poll();
            sum += (double) c[0] / c[1];
        }
        return sum / count;
    }

    public static int compare(int[] a, int[] b) {
        double changeA = ((double) a[0] + 1) / (a[1] + 1) - (double) a[0] / a[1];
        double changeB = ((double) b[0] + 1) / (b[1] + 1) - (double) b[0] / b[1];
        return changeB > changeA ? 1 : -1;
    }
}
