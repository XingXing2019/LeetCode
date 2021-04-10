package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        char[][] board = new char[][]{
                new char[]{'O', 'O'},
                new char[]{'O', 'O'}
        };
        solve(board);
    }

    public static void solve(char[][] board) {
        boolean[][] visited = new boolean[board.length][board[0].length];
        int[] dir = {0, 1, 0, -1, 0};
        for (int x = 0; x < board.length; x++) {
            if (!visited[x][0] && board[x][0] == 'O')
                bfs(board, visited, x, 0, dir);
            if (!visited[x][board[0].length - 1] && board[x][board[0].length - 1] == 'O')
                bfs(board, visited, x, board[0].length - 1, dir);
        }
        for (int y = 0; y < board[0].length; y++) {
            if (!visited[0][y] && board[0][y] == 'O')
                bfs(board, visited, 0, y, dir);
            if (!visited[board.length - 1][y] && board[board.length - 1][y] == 'O')
                bfs(board, visited, board.length - 1, y, dir);
        }
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                if (!visited[x][y] && board[x][y] == 'O')
                    board[x][y] = 'X';
            }
        }
    }

    public static void bfs(char[][] board, boolean[][] visited, int x, int y, int[] dir) {
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(new int[]{x, y});
        visited[x][y] = true;
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + dir[i];
                int newY = cur[1] + dir[i + 1];
                if (newX < 0 || newX >= board.length || newY < 0 || newY >= board[0].length)
                    continue;
                if (!visited[newX][newY] && board[newX][newY] == 'O') {
                    queue.offer(new int[]{newX, newY});
                    visited[newX][newY] = true;
                }
            }
        }
    }
}
