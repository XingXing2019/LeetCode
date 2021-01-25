package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int numDistinctIslands(int[][] grid) {
        if(grid.length == 0 || grid[0].length == 0) return 0;
        int[][] mark = new int[grid.length][];
        for (int i = 0; i < mark.length; i++)
            mark[i] = new int[grid[0].length];
        HashSet<String> set = new HashSet<>();
        for (int x = 0; x < grid.length; x++) {
            for (int y = 0; y < grid[0].length; y++) {
                if(mark[x][y] == 1 || grid[x][y] == 0) continue;
                String code = dfs(grid, mark, x, y, x, y);
                set.add(code);
            }
        }
        return set.size();
    }

    public String dfs(int[][] grid, int[][] mark, int x, int y, int oX, int oY){
        if(x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || mark[x][y] == 1 || grid[x][y] == 0)
            return "";
        mark[x][y] = 1;
        String code = "";
        code += Integer.toString(oX - x) + ":" + Integer.toString(oY - y);
        code += dfs(grid, mark, x + 1, y, oX, oY);
        code += dfs(grid, mark, x - 1, y, oX, oY);
        code += dfs(grid, mark, x, y + 1, oX, oY);
        code += dfs(grid, mark, x, y - 1, oX, oY);
        return code;
    }
}
