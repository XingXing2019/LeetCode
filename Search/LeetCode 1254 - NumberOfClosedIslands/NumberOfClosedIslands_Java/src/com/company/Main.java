package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] grid = {{1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0}, {1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1}};
        System.out.println(closedIsland(grid));
    }

    public static int closedIsland(int[][] grid) {
        var res = 0;
        for (int i = 0; i < grid.length; i++) {
            if (grid[i][0] == 0)
                dfs(grid, i, 0);
            if (grid[i][grid[0].length - 1] == 0)
                dfs(grid, i, grid[0].length - 1);
        }
        for (int j = 0; j < grid[0].length; j++) {
            if (grid[0][j] == 0)
                dfs(grid, 0, j);
            if (grid[grid.length - 1][j] == 0)
                dfs(grid, grid.length - 1, j);
        }
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] != 0) continue;
                dfs(grid, i, j);
                res++;
            }
        }
        return res;
    }

    public static void dfs(int[][] grid, int x, int y) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] != 0)
            return;
        grid[x][y] = 2;
        dfs(grid, x + 1, y);
        dfs(grid, x - 1, y);
        dfs(grid, x, y + 1);
        dfs(grid, x, y - 1);
    }
}
