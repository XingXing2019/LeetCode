package com.company;

import java.util.ArrayDeque;

public class Main {

    public static void main(String[] args) {
        int[][] grid = new int[][]{
                new int[]{2, 1, 1},
                new int[]{0, 1, 1},
                new int[]{1, 0, 1},
        };
        orangesRotting(grid);
    }

    public static int orangesRotting(int[][] grid) {
        ArrayDeque<int[]> queue = new ArrayDeque<>();
        int fresh = 0, time = 0;
        boolean[][] visited = new boolean[grid.length][grid[0].length];
        for (int x = 0; x < grid.length; x++) {
            for (int y = 0; y < grid[0].length; y++) {
                if (grid[x][y] == 1) fresh++;
                else if (grid[x][y] == 2) {
                    queue.offer(new int[]{x, y});
                    visited[x][y] = true;
                }
            }
        }
        if (queue.isEmpty()) return fresh == 0 ? 0 : -1;
        int[] dir = {0, 1, 0, -1, 0};
        while (!queue.isEmpty()) {
            int count = queue.size();
            time++;
            for (int i = 0; i < count; i++) {
                int[] cur = queue.poll();
                for (int j = 0; j < 4; j++) {
                    int newX = cur[0] + dir[j];
                    int newY = cur[1] + dir[j + 1];
                    if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length)
                        continue;
                    if (!visited[newX][newY] && grid[newX][newY] == 1) {
                        visited[newX][newY] = true;
                        queue.offer(new int[]{newX, newY});
                        fresh--;
                    }
                }
            }
        }
        return fresh == 0 ? time - 1 : -1;
    }
}
