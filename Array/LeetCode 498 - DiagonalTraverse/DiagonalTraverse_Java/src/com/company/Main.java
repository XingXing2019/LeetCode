package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] matrix = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
        };
        findDiagonalOrder(matrix);
    }

    public static int[] findDiagonalOrder(int[][] matrix) {
        if(matrix.length == 0 || matrix[0].length == 0) return new int[0];
        int[][] dir = {{-1, 1}, {1, -1}};
        int x = 0, y = 0, index = 0, row = matrix.length, col = matrix[0].length;
        int[] res = new int[row * col];
        for (int i = 0; i < res.length; i++) {
            res[i] = matrix[x][y];
            x += dir[index % 2][0];
            y += dir[index % 2][1];
            if (x >= 0 && x < row && y >= 0 && y < col) continue;
            if (x >= row) {
                x--;
                y += 2;
            } else if (y >= col) {
                y--;
                x += 2;
            }
            if (x < 0)
                x++;
            else if (y < 0)
                y++;
            index++;
        }
        return res;
    }
}
