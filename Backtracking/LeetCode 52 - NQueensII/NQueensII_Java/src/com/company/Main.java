package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 2;
    }
    int res;
    public int totalNQueens(int n) {
        boolean[][] board = new boolean[n][n];
        dfs(n, 0, board);
        return res;
    }

    public void updateBoard(boolean[][] board, int x, int y) {
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j <= board.length; j++) {
                int newX = x + dx[i] * j;
                int newY = y + dy[i] * j;
                if (newX < 0 || newX >= board.length || newY < 0 || newY >= board.length)
                    break;
                board[newX][newY] = true;
            }
        }
    }

    public boolean[][] copyBoard(boolean[][] board){
        boolean[][] copy = new boolean[board.length][board[0].length];
        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[0].length; j++) {
                copy[i][j] = board[i][j];
            }
        }
        return copy;
    }

    public void dfs(int n, int row, boolean[][] board) {
        if (row == n) {
            res++;
            return;
        }
        for (int col = 0; col < board.length; col++) {
            if(!board[row][col]){
                boolean[][] copy = copyBoard(board);
                updateBoard(board, row, col);
                dfs(n, row + 1, board);
                board = copy;
            }
        }
    }
}
