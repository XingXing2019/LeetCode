package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[][] mat = new int[][]{
                new int[]{1, 1, 1, 1, 1},
                new int[]{1, 0, 0, 0, 0},
                new int[]{1, 1, 0, 0, 0},
                new int[]{1, 1, 1, 1, 0},
                new int[]{1, 1, 1, 1, 1},
        };
        int k = 3;
        kWeakestRows(mat, 3);
    }


    public static int[] kWeakestRows(int[][] mat, int k) {
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        for (int i = 0; i < mat.length; i++) {
            int li = 0, hi = mat[i].length - 1;
            while (li <= hi) {
                int mid = li + (hi - li) / 2;
                if (mat[i][mid] == 0) hi = mid - 1;
                else li = mid + 1;
            }
            heap.offer(new int[]{li, i});
        }
        int[] res = new int[k];
        for (int i = 0; i < res.length; i++)
            res[i] = heap.poll()[1];
        return res;
    }

}
