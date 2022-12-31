package com.company;

public class Main {

    public static void main(String[] args) {

    }

    int res;
    public int uniquePathsIII(int[][] grid) {
        int count = 0, m = grid.length, n = grid[0].length;
        int[] start = new int[2], end = new int[2];
        boolean[][] visited = new boolean[m][n];
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] == 1)
                    start = new int[]{i, j};
                else if (grid[i][j] == 2)
                    end = new int[]{i, j};
                else if (grid[i][j] == 0)
                    count++;
            }
        }
        visited[start[0]][start[1]] = true;
        dfs(grid, start[0], start[1], count, end, visited);
        return res;
    }

    public void dfs(int[][] grid, int x, int y, int count, int[] end, boolean[][] visited) {
        if (count == 0 && x == end[0] && y == end[1]) {
            res++;
            return;
        }
        int[] dir = {1, 0, -1, 0, 1};
        for (int i = 0; i < 4; i++) {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length || visited[newX][newY] || grid[newX][newY] == -1)
                continue;
            visited[newX][newY] = true;
            dfs(grid, newX, newY, grid[newX][newY] == 0 ? count - 1 : count, end, visited);
            visited[newX][newY] = false;
        }
    }
}
