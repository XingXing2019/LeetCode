package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int islandPerimeter(int[][] grid) {
        int res = 0;
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] == 0) continue;
                res += 4;
                res -= i != 0 && grid[i - 1][j] == 1 ? 1 : 0;
                res -= i != grid.length - 1 && grid[i + 1][j] == 1 ? 1 : 0;
                res -= j != 0 && grid[i][j - 1] == 1 ? 1 : 0;
                res -= j != grid[0].length - 1 && grid[i][j + 1] == 1 ? 1 : 0;
            }
        }
        return res;
    }
}
