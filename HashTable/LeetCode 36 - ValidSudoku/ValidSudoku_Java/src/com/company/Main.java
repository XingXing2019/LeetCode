package com.company;

public class Main {

    public static void main(String[] args) {
        char[][] board = {
                {'.', '.', '.', '.', '5', '.', '.', '1', '.' },
                {'.', '4', '.', '3', '.', '.', '.', '.', '.' },
                {'.', '.', '.', '.', '.', '3', '.', '.', '1' },
                {'8', '.', '.', '.', '.', '.', '.', '2', '.' },
                {'.', '.', '2', '.', '7', '.', '.', '.', '.' },
                {'.', '1', '5', '.', '.', '.', '.', '.', '.' },
                {'.', '.', '.', '.', '.', '2', '.', '.', '.' },
                {'.', '2', '.', '9', '.', '.', '.', '.', '.' },
                {'.', '.', '4', '.', '.', '.', '.', '.', '.' },
        };
        System.out.println(isValidSudoku(board));
    }

    public static boolean isValidSudoku(char[][] board) {
        for (int i = 0; i < 9; i++) {
            var record = new int[10];
            for (int j = 0; j < 9; j++) {
                if (board[i][j] == '.') continue;
                record[board[i][j] - '0']++;
                if (record[board[i][j] - '0'] > 1)
                    return false;
            }
        }
        for (int j = 0; j < 9; j++) {
            var record = new int[10];
            for (int i = 0; i < 9; i++) {
                if (board[i][j] == '.') continue;
                record[board[i][j] - '0']++;
                if (record[board[i][j] - '0'] > 1)
                    return false;
            }
        }
        for (int row = 0; row < 9; row += 3) {
            for (int col = 0; col < 9; col += 3) {
                var record = new int[10];
                for (int i = row; i < row + 3; i++) {
                    for (int j = col; j < col + 3; j++) {
                        if (board[i][j] == '.') continue;
                        record[board[i][j] - '0']++;
                        if (record[board[i][j] - '0'] > 1)
                            return false;
                    }
                }
            }
        }
        return true;
    }
}
