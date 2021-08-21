package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public void solveSudoku(char[][] board) {
        boolean[][] rowUsed = new boolean[9][9];
        boolean[][] colUsed = new boolean[9][9];
        boolean[][] gridUsed = new boolean[9][9];
        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                if (board[r][c] == '.') continue;
                int num = board[r][c] - '1';
                int index = r / 3 * 3 + c / 3;
                rowUsed[r][num] = true;
                colUsed[c][num] = true;
                gridUsed[index][num] = true;
            }
        }
        DFS(board, rowUsed, colUsed, gridUsed);
    }

    public boolean DFS(char[][] board, boolean[][] rowUsed, boolean[][] colUsed, boolean[][] gridUsed) {
        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                if (board[r][c] != '.') continue;
                for (int i = 0; i < 9; i++) {
                    int index = r / 3 * 3 + c / 3;
                    if (rowUsed[r][i] || colUsed[c][i] || gridUsed[index][i]) continue;
                    rowUsed[r][i] = true;
                    colUsed[c][i] = true;
                    gridUsed[index][i] = true;
                    board[r][c] = (char) (i + '1');
                    if (DFS(board, rowUsed, colUsed, gridUsed))
                        return true;
                    rowUsed[r][i] = false;
                    colUsed[c][i] = false;
                    gridUsed[index][i] = false;
                    board[r][c] = '.';
                }
                return false;
            }
        }
        return true;
    }
}
