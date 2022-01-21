package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] matrix = {{0, 1, 0}, {1, 1, 1}, {0, 1, 0}};
        int target = 0;
        System.out.println(numSubmatrixSumTarget(matrix, target));
    }

    public static int numSubmatrixSumTarget(int[][] matrix, int target) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                if (i == 0 && j == 0) continue;
                else if (i == 0 && j != 0) matrix[i][j] += matrix[i][j - 1];
                else if (i != 0 && j == 0) matrix[i][j] += matrix[i - 1][j];
                else matrix[i][j] += matrix[i - 1][j] + matrix[i][j - 1] - matrix[i - 1][j - 1];
            }
        }
        var res = 0;
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                int[] p1 = new int[] {i, j};
                for (int x = 0; x <= i; x++) {
                    for (int y = 0; y <= j; y++) {
                        int[] p2 = new int[] {x, y};
                        if (getArea(matrix, p1, p2) == target)
                            res++;
                    }
                }
            }
        }
        return res;
    }

    public static int getArea(int[][] matrix, int[] p1, int[] p2) {
        var area = matrix[p1[0]][p1[1]];
        if (p2[0] != 0) area -= matrix[p2[0] - 1][p1[1]];
        if (p2[1] != 0) area -= matrix[p1[0]][p2[1] - 1];
        if (p2[0] != 0 && p2[1] != 0) area += matrix[p2[0] - 1][p2[1] - 1];
        return area;
    }
}
