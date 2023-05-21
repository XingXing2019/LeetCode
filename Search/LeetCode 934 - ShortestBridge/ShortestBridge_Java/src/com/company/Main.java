package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int[][] grid = {{0,0,1,0,1}, {0,1,1,0,1}, {0,1,0,0,1}, {0,0,0,0,0}, {0,0,0,0,0}};
        System.out.println(shortestBridge(grid));
    }

    public static int shortestBridge(int[][] grid) {
        Queue<int[]> first = new ArrayDeque<>();
        boolean found = false;
        for (int x = 0; x < grid.length; x++) {
            if (found) break;
            for (int y = 0; y < grid[0].length; y++) {
                if (grid[x][y] == 0) continue;
                dfs(grid, x, y, first);
                found = true;
                break;
            }
        }
        int[] dir = {1, 0, -1, 0, 1};
        while (!first.isEmpty()) {
            int[] cur = first.poll();
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length || grid[newX][newY] == 2)
                    continue;
                if (grid[newX][newY] == 1)
                    return cur[2];
                grid[newX][newY] = 2;
                first.offer(new int[]{newX, newY, cur[2] + 1});
            }
        }
        return -1;
    }

    public static void dfs(int[][] grid, int x, int y, Queue<int[]> first) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] != 1)
            return;
        first.add(new int[]{x, y, 0});
        grid[x][y] = 2;
        dfs(grid, x + 1, y, first);
        dfs(grid, x - 1, y, first);
        dfs(grid, x, y + 1, first);
        dfs(grid, x, y - 1, first);
    }
}
