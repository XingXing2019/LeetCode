package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int knightDialer(int n) {
        if (n == 1) return 10;
        int mod = 1_000_000_000 + 7;
        long[][] board = new long[4][3];
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                if(x == 1 && y == 1 || x == 3 && y == 0 || x == 3 && y == 2)
                    continue;
                board[x][y] = 1;
            }
        }
        for (int i = 1; i < n; i++) {
            long[][] newBoard = new long[4][3];
            newBoard[0][0] = (board[1][2] + board[2][1]) % mod;
            newBoard[0][1] = (board[2][0] + board[2][2]) % mod;
            newBoard[0][2] = (board[1][0] + board[2][1]) % mod;
            newBoard[1][0] = (board[0][2] + board[2][2] + board[3][1]) % mod;
            newBoard[1][2] = (board[0][0] + board[2][0] + board[3][1]) % mod;
            newBoard[2][0] = (board[0][1] + board[1][2]) % mod;
            newBoard[2][1] = (board[0][0] + board[0][2]) % mod;
            newBoard[2][2] = (board[0][1] + board[1][0]) % mod;
            newBoard[3][1] = (board[1][0] + board[1][2]) % mod;
            board = newBoard;
        }
        long res = 0;
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                res += board[x][y];
            }
        }
        return (int)(res % mod);
    }
}
