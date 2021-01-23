package com.company;

import java.util.ArrayList;
import java.util.Collections;

public class Main {

    public static void main(String[] args) {
        int[][] mat = new int[][]{
                new int[]{3, 3, 1, 1},
                new int[]{2, 2, 1, 2},
                new int[]{1, 1, 1, 2},
        };
        System.out.print(DiagonalSort(mat));
    }

    public static int[][] DiagonalSort(int[][] mat) {
        for (int c = 0; c < mat[0].length; c++) {
            ArrayList<Integer> temp = new ArrayList<>();
            int k = 0;
            while (k < mat.length && c + k < mat[0].length) {
                temp.add(mat[k][c + k]);
                k++;
            }
            k--;
            Collections.sort(temp);
            while (k >= 0)
                mat[k][c + k] = temp.get(k--);
        }
        for (int r = 1; r < mat.length; r++) {
            ArrayList<Integer> temp = new ArrayList<>();
            int k = 0;
            while (r + k < mat.length && k < mat[0].length) {
                temp.add(mat[r + k][k]);
                k++;
            }
            k--;
            Collections.sort(temp);
            while (k >= 0)
                mat[r + k][k] = temp.get(k--);
        }
        return mat;
    }
}
