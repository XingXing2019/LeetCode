package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] martrix = {{3, 0, 1, 4, 2}, {5, 6, 3, 2, 1}, {1, 2, 0, 1, 5}, {4, 1, 0, 1, 7}, {1, 0, 3, 0, 5}};
        NumMatrix m = new NumMatrix(martrix);
        System.out.println(m.sumRegion(2, 1, 4, 3));
        System.out.println(m.sumRegion(1, 1, 2, 2));
        System.out.println(m.sumRegion(1, 0, 2, 4));
    }
}
class NumMatrix {
    int[][] _matrix;
    public NumMatrix(int[][] matrix) {
        for (int c = 0; c < matrix[0].length; c++) {
            for (int r = 1; r < matrix.length; r++) {
                matrix[r][c] += matrix[r - 1][c];
            }
        }
        for (int r = 0; r < matrix.length; r++) {
            for (int c = 1; c < matrix[0].length; c++) {
                matrix[r][c] += matrix[r][c - 1];
            }
        }
        _matrix = matrix;
    }

    public int sumRegion(int row1, int col1, int row2, int col2) {
        int num1 = _matrix[row2][col2];
        int num2 = row1 == 0 ? 0 : _matrix[row1 - 1][col2];
        int num3 = col1 == 0 ? 0 : _matrix[row2][col1 - 1];
        int num4 = row1 == 0 || col1 == 0 ? 0 : _matrix[row1- 1][col1 - 1];
        return (num1 - num2) - (num3 - num4);
    }
}