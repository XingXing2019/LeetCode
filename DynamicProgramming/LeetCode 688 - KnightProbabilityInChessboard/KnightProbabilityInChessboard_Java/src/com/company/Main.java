package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 4, k = 2, row = 0, column = 0;
        System.out.println(knightProbability(n, k, row, column));
    }

    public static double knightProbability(int n, int k, int row, int column) {
        double[][] board = new double[n][n];
        board[row][column] = 1;
        for (int i = 0; i < k; i++)
            board = updateBoard(board, n);
        double res = 0;
        for (int x = 0; x < n; x++) {
            for (int y = 0; y < n; y++)
                res += board[x][y];
        }
        return res;
    }

    private static double[][] updateBoard(double[][] board, int n) {
        double[][] res = new double[n][n];
        int[] dx = {-2, -1, 1, 2, 2, 1, -1, -2};
        int[] dy = {1, 2, 2, 1, -1, -2, -2, -1};
        for (int x = 0; x < n; x++) {
            for (int y = 0; y < n; y++) {
                if (board[x][y] == 0) continue;
                for (int i = 0; i < 8; i++) {
                    int newX = x + dx[i], newY = y + dy[i];
                    if (newX < 0 || newX >= n || newY < 0 || newY >= n) continue;
                    res[newX][newY] += board[x][y] * 0.125;
                }
            }
        }
        return res;
    }
}
