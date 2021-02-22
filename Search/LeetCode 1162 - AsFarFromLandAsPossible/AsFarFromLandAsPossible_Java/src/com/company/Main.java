package com.company;

import java.util.ArrayDeque;

public class Main {

    public static void main(String[] args) {
        int[][] grid = new int[][]{
                new int[]{1, 0, 0},
                new int[]{0, 0, 0},
                new int[]{0, 0, 0}
        };
        maxDistance(grid);
    }

    public static int maxDistance(int[][] grid) {
        boolean[][] visited = new boolean[grid.length][grid[0].length];
        ArrayDeque<int[]> queue = new ArrayDeque();
        for (int x = 0; x < grid.length; x++) {
            for (int y = 0; y < grid[0].length; y++) {
                if (grid[x][y] == 1) {
                    visited[x][y] = true;
                    queue.offer(new int[]{x, y});
                }
            }
        }
        if(queue.isEmpty() || queue.size() == grid.length * grid[0].length) return -1;
        int[] dir = {0, 1, 0, -1, 0};
        int level = 0;
        while (!queue.isEmpty()) {
            int count = queue.size();
            level++;
            for (int i = 0; i < count; i++) {
                int[] cur = queue.poll();
                for (int j = 0; j < 4; j++) {
                    int newX = cur[0] + dir[j];
                    int newY = cur[1] + dir[j + 1];
                    if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length)
                        continue;
                    if(!visited[newX][newY]){
                        visited[newX][newY] = true;
                        queue.offer(new int[]{newX, newY});
                    }
                }
            }
        }
        return level - 1;
    }
}
