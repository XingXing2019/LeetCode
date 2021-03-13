package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 3;
        generateMatrix(n);
    }
    public static int[][] generateMatrix(int n) {
        int[][] res = new int[n][n];
        boolean[][] mark = new boolean[n][n];
        int[][] dir = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        int index = 0, x = 0, y = 0;
        for (int i = 1; i <= n * n; i++) {
            res[x][y] = i;
            mark[x][y] = true;
            if (i == n * n) break;
            int newX = x + dir[index % 4][0], newY = y + dir[index % 4][1];
            if (newX < 0 || newX >= n || newY < 0 || newY >= n || mark[newX][newY]) {
                index++;
                i--;
                continue;
            }
            x = newX;
            y = newY;
        }
        return res;
    }
}
