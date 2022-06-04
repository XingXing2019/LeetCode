package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<List<String>> solveNQueens(int n) {
        boolean[][] occupied = new boolean[n][n];
        List<StringBuilder> board = new ArrayList<>();
        for (int i = 0; i < n; i++)
            board.add(new StringBuilder(".".repeat(n)));
        List<List<String>> res = new ArrayList<>();
        dfs(0, n, occupied, board, res);
        return res;
    }

    public void dfs(int x, int n, boolean[][] occupied, List<StringBuilder> board, List<List<String>> res) {
        if (x == n) {
            List<String> temp = new ArrayList<>();
            for (StringBuilder row : board)
                temp.add(row.toString());
            res.add(temp);
            return;
        }
        for (int y = 0; y < n; y++) {
            if (occupied[x][y]) continue;
            boolean[][] copy = copy(occupied, n);
            mark(x, y, n, occupied);
            board.get(x).setCharAt(y, 'Q');
            dfs(x + 1, n, occupied, board, res);
            board.get(x).setCharAt(y, '.');
            occupied = copy;
        }
    }

    public boolean[][] copy(boolean[][] occupied, int n) {
        boolean[][] copy = new boolean[n][n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                copy[i][j] = occupied[i][j];
            }
        }
        return copy;
    }

    public void mark(int x, int y, int n, boolean[][] occupied) {
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < n; j++) {
                int newX = x + dx[i] * j, newY = y + dy[i] * j;
                if (newX < 0 || newX >= n || newY < 0 || newY >= n)
                    break;
                occupied[newX][newY] = true;
            }
        }
    }
}
