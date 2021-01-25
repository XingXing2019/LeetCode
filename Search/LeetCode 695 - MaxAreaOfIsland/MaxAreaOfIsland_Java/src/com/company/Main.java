package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int maxAreaOfIsland(int[][] grid) {
        int[][] mark = new int[grid.length][];
        for (int i = 0; i < mark.length; i++)
            mark[i] = new int[grid[0].length];
        int res = 0;
        for (int x = 0; x < grid.length; x++) {
            for (int y = 0; y < grid[0].length; y++) {
                if(grid[x][y] != 1 || mark[x][y] != 0) continue;
                res = Math.max(res, dfs(grid, mark, x, y));
            }
        }
        return res;
    }

    public int dfs(int[][] grid, int[][] mark, int x, int y){
        if(x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || mark[x][y] == 1 || grid[x][y] == 0)
            return 0;
        mark[x][y] = 1;
        int area = 0;
        area++;
        area += dfs(grid, mark, x + 1, y);
        area += dfs(grid, mark, x - 1, y);
        area += dfs(grid, mark, x, y + 1);
        area += dfs(grid, mark, x, y - 1);
        return area;
    }
}
