package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[][] tasks = new int[][]{
                new int[]{19, 13},
                new int[]{16, 9},
                new int[]{45, 4},
                new int[]{18, 18},
                new int[]{46, 39},
                new int[]{12, 24},
        };
        System.out.println(getOrder(tasks));
    }

    public static int[] getOrder(int[][] tasks) {
        int[] res = new int[tasks.length];
        int[][] taskIndexes = new int[tasks.length][];
        for (int i = 0; i < tasks.length; i++)
            taskIndexes[i] = new int[]{tasks[i][0], tasks[i][1], i};
        Arrays.sort(taskIndexes, Comparator.comparingInt(a -> a[0]));
        int p1 = 0, p2 = 0;
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[1] == b[1] ? a[2] - b[2] : a[1] - b[1]);
        while (p1 < taskIndexes.length) {
            int start = taskIndexes[p1][0];
            while (p1 < taskIndexes.length && taskIndexes[p1][0] <= start)
                heap.offer(taskIndexes[p1++]);
            while (!heap.isEmpty()) {
                int[] task = heap.poll();
                res[p2++] = task[2];
                start += task[1];
                while (p1 < taskIndexes.length && taskIndexes[p1][0] <= start)
                    heap.offer(taskIndexes[p1++]);
            }
        }
        return res;
    }
}
