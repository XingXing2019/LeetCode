package com.company;

import java.util.LinkedList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[][] matrix = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
        };
        spiralOrder(matrix);
    }

    public static List<Integer> spiralOrder(int[][] matrix) {
        List<Integer> res = new LinkedList<>();
        int[][] dir = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        boolean[][] mark = new boolean[matrix.length][matrix[0].length];
        int index = 0, x = 0, y = 0;
        for (int i = 0; i < matrix.length * matrix[0].length; i++) {
            res.add(matrix[x][y]);
            mark[x][y] = true;
            int newX = x + dir[index % 4][0], newY = y + dir[index % 4][1];
            if (newX < 0 || newX >= mark.length || newY < 0 || newY >= mark[0].length || mark[newX][newY])
                index++;
            x += dir[index % 4][0];
            y += dir[index % 4][1];
        }
        return res;
    }
}
