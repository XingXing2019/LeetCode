package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public static String tictactoe(int[][] moves) {
        int[][] board = new int[3][3];
        for (int i = 0; i < moves.length; i++)
            board[moves[i][0]][moves[i][1]] = i % 2 == 0 ? 1 : 2;
        if (check(board, 1)) return "A";
        if (check(board, 2)) return "B";
        if (moves.length < 9) return "Pending";
        return "Draw";
    }

    public static boolean check(int[][] board, int player) {
        for (int i = 0; i < 3; i++) {
            int count = 0;
            for (int j = 0; j < 3; j++) {
                if (board[i][j] == player) count++;
            }
            if (count == 3) return true;
        }
        for (int j = 0; j < 3; j++) {
            int count = 0;
            for (int i = 0; i < 3; i++) {
                if (board[i][j] == player) count++;
            }
            if (count == 3) return true;
        }
        if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
            return true;
        return board[0][2] == player && board[1][1] == player && board[2][0] == player;
    }
}
