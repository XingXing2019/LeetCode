package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] matrix = {{1, 0, 1}, {0, -2, 3}};
        int k = 2;
        System.out.println(maxSumSubmatrix(matrix, k));
    }

    public static int maxSumSubmatrix(int[][] matrix, int k) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                if (i == 0 && j == 0) continue;
                else if (i == 0 && j != 0) matrix[i][j] += matrix[i][j - 1];
                else if (i != 0 && j == 0) matrix[i][j] += matrix[i - 1][j];
                else matrix[i][j] += matrix[i - 1][j] + matrix[i][j - 1] - matrix[i - 1][j - 1];
            }
        }
        int res = Integer.MIN_VALUE;
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                for (int m = 0; m <= i; m++) {
                    for (int n = 0; n <= j; n++) {
                        int sum = matrix[i][j];
                        sum -= m == 0 ? 0 : matrix[m - 1][j];
                        sum -= n == 0 ? 0 : matrix[i][n - 1];
                        sum += m == 0 || n == 0 ? 0 : matrix[m - 1][n - 1];
                        if (sum <= k)
                            res = Math.max(res, sum);
                    }
                }
            }
        }
        return res;
    }
}
