package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	    int[][] matrix = {{9, 9}, {6, 6}, {2, 1}};
        System.out.println(longestIncreasingPath(matrix));
    }

    public static int longestIncreasingPath(int[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        int[][] path = new int[m][n];
        boolean[][] visited = new boolean[m][n];
        for (int i = 0; i < m; i++)
            Arrays.fill(path[i], 1);
        var res = 0;
        for (int x = 0; x < m; x++) {
            for (int y = 0; y < n; y++) {
                dfs(matrix, path, visited, x, y, x, y);
                res = Math.max(res, path[x][y]);
            }
        }
        return res;
    }

    public static int dfs(int[][] matrix, int[][] path, boolean[][] visited, int x, int y, int oX, int oY) {
        int m = matrix.length, n = matrix[0].length;
        if (x < 0 || x >= m || y < 0 || y >= n)
            return 0;
        if ((x != oX || y != oY) && matrix[x][y] <= matrix[oX][oY])
            return 0;
        if (visited[x][y])
            return path[x][y];
        visited[x][y] = true;
        int[] dirs = {1, 0, -1, 0, 1};
        var max = 0;
        for (int i = 0; i < 4; i++) {
            int newX = x + dirs[i], newY = y + dirs[i + 1];
            max = Math.max(max, dfs(matrix, path, visited, newX, newY, x, y));
        }
        path[x][y] += max;
        return path[x][y];
    }
}
