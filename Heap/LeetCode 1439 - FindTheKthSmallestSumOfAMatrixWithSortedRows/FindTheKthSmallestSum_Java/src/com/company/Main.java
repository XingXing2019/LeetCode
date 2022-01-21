package com.company;

import java.util.Arrays;
import java.util.HashSet;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public static int kthSmallest(int[][] mat, int k) {
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[0] - b[0]);
        int[] min = new int[mat.length + 1];
        for (int[] row : mat) min[0] += row[0];
        HashSet<String> visited = new HashSet<>();
        heap.offer(min);
        visited.add(join(min));
        for (int i = 1; i < k; i++) {
            int[] cur = heap.poll();
            for (int j = 0; j < mat.length; j++) {
                int index = cur[j + 1];
                if (index == mat[0].length - 1) continue;
                int[] larger = Arrays.copyOf(cur, cur.length);
                larger[0] = larger[0] - mat[j][index] + mat[j][index + 1];
                larger[j + 1] = index + 1;
                if (visited.add(join(larger)))
                    heap.offer(larger);
            }
        }
        return heap.peek()[0];
    }

    public static String join(int[] arr) {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < arr.length; i++) {
            res.append(arr[i]);
            if (i != arr.length - 1) res.append('-');
        }
        return res.toString();
    }
}
