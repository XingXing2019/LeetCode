package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public void setZeroes(int[][] matrix) {
        var isZero = false;
        for (int r = 0; r < matrix.length; r++) {
            isZero = isZero || matrix[r][0] == 0;
            for (int c = 1; c < matrix[0].length; c++) {
                if (matrix[r][c] == 0) {
                    matrix[r][0] = 0;
                    matrix[0][c] = 0;
                }
            }
        }
        for (int r = 1; r < matrix.length; r++) {
            for (int c = 1; c < matrix[0].length; c++) {
                if (matrix[r][0] == 0 || matrix[0][c] == 0)
                    matrix[r][c] = 0;
            }
        }
        if (matrix[0][0] == 0) {
            for (int c = 0; c < matrix[0].length; c++)
            matrix[0][c] = 0;
        }
        if (isZero) {
            for (int r = 0; r < matrix.length; r++)
                matrix[r][0] = 0;
        }
    }
}
