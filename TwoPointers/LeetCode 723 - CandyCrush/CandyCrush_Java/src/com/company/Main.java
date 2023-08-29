package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] board = {
                {110, 5, 112, 113, 114},
                {210, 211, 5, 213, 214},
                {310, 311, 3, 313, 314},
                {410, 411, 412, 5, 414},
                {5, 1, 512, 3, 3},
                {610, 4, 1, 613, 614},
                {710, 1, 2, 713, 714},
                {810, 1, 2, 1, 1},
                {1, 1, 2, 2, 2},
                {4, 1, 4, 4, 1014}
        };
        System.out.println(candyCrush(board));
    }

    public static int[][] candyCrush(int[][] board) {
        boolean isColStable = flagColumns(board);
        boolean isRowStable = flagRows(board);
        if (isColStable && isRowStable)
            return board;
        for (int c = 0; c < board[0].length; c++) {
            int li = board.length - 1, hi = li;
            while (li >= 0) {
                if (hi < 0)
                    board[li--][c] = 0;
                else if (board[hi][c] > 0) {
                    board[li--][c] = board[hi--][c];
                } else
                    hi--;
            }
        }
        return candyCrush(board);
    }

    public static boolean flagColumns(int[][] board) {
        boolean isStable = true;
        for (int c = 0; c < board[0].length; c++) {
            int num = Math.abs(board[0][c]), count = 0;
            for (int r = 0; r < board.length; r++) {
                if (Math.abs(board[r][c]) == num)
                    count++;
                else {
                    if (count >= 3 && num != 0) {
                        isStable = false;
                        flipBoard(board, r - 1, c, count, false);
                    }
                    num = Math.abs(board[r][c]);
                    count = 1;
                }
            }
            if (count >= 3 && num != 0) {
                isStable = false;
                flipBoard(board, board.length - 1, c, count, false);
            }
        }
        return isStable;
    }

    public static boolean flagRows(int[][] board) {
        boolean isStable = true;
        for (int r = 0; r < board.length; r++) {
            int num = Math.abs(board[r][0]), count = 0;
            for (int c = 0; c < board[0].length; c++) {
                if (Math.abs(board[r][c]) == num)
                    count++;
                else {
                    if (count >= 3 && num != 0) {
                        isStable = false;
                        flipBoard(board, c - 1, r, count, true);
                    }
                    num = Math.abs(board[r][c]);
                    count = 1;
                }
            }
            if (count >= 3 && num != 0) {
                isStable = false;
                flipBoard(board, board[0].length - 1, r, count, true);
            }
        }
        return isStable;
    }

    private static void flipBoard(int[][] board, int move, int fix, int count, boolean isRow) {
        while (count != 0) {
            if (isRow)
                board[fix][move] = -Math.abs(board[fix][move--]);
            else
                board[move][fix] = -Math.abs(board[move--][fix]);
            count--;
        }
    }
}
