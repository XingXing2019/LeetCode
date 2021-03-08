package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public void gameOfLife(int[][] board) {
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                int one = 0;
                for (int i = 0; i < 8; i++) {
                    int newX = x + dx[i];
                    int newY = y + dy[i];
                    if(newX < 0 || newX >= board.length || newY < 0 || newY >= board[0].length)
                        continue;
                    if(board[newX][newY] == 1 || board[newX][newY] == -1) one++;
                }
                if(board[x][y] == 1 && (one < 2 || one > 3))
                    board[x][y] = -1;
                if(board[x][y] == 0 && one == 3)
                    board[x][y] = -2;
            }
        }
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                if(board[x][y] < 0)
                    board[x][y] = -board[x][y] - 1;
            }
        }
    }
}
