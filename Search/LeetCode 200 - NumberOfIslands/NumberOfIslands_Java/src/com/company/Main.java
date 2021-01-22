package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int numIslands(char[][] grid) {
        var mark = new int[grid.length][];
        for (int i = 0; i < mark.length; i++)
            mark[i] = new int[grid[0].length];
        var res = 0;
        for (int x = 0; x < grid.length; x++) {
            for (int y = 0; y < grid[0].length; y++) {
                if(mark[x][y] == 1 || grid[x][y] == '0') continue;
                DFS(grid, mark, x, y);
                res++;
            }
        }
        return res;
    }

    public void DFS(char[][] grid, int[][] mark, int x, int y){
        mark[x][y] = 1;
        int[] dx = {-1, 1, 0, 0};
        int[] dy = {0, 0, -1, 1};
        for (int i = 0; i < 4; i++) {
            int newX = dx[i] + x;
            int newY = dy[i] + y;
            if(newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length)
                continue;
            if(mark[newX][newY] == 0 && grid[newX][newY] == '1')
                DFS(grid, mark, newX, newY);
        }
    }
}
