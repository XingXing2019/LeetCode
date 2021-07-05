package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[][] matrixReshape(int[][] mat, int r, int c) {
        if (r * c != mat.length * mat[0].length)
            return mat;
        int[][] res = new int[r][c];
        r = 0;
        c = 0;
        for (int i = 0; i < mat.length; i++) {
            for (int j = 0; j < mat[0].length; j++) {
                res[r][c] = mat[i][j];
                c++;
                if (c == res[0].length) {
                    c = 0;
                    r++;
                }
            }
        }
        return res;
    }
}
