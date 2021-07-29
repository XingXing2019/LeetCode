package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] mat = {{0, 1, 1, 1, 1}, {1, 1, 1, 1, 0}};
        System.out.println(updateMatrix(mat));
    }

    public static int[][] updateMatrix(int[][] mat) {
        int[][] res = new int[mat.length][mat[0].length];
        for (int x = 0; x < mat.length; x++) {
            for (int y = 0; y < mat[0].length; y++) {
                if (mat[x][y] == 0) continue;
                res[x][y] = dfs(mat, res, x, y);
            }
        }
        return res;
    }

    public static int dfs(int[][] mat, int[][] res, int x, int y) {
        if (mat[x][y] == 0) return 0;
        if (x > 0 && mat[x - 1][y] == 0 || x < mat.length - 1 && mat[x + 1][y] == 0)
            return 1;
        if (y > 0 && mat[x][y - 1] == 0 || y < mat[0].length - 1 && mat[x][y + 1] == 0)
            return 1;
        int min = Integer.MAX_VALUE - 1;
        if (x > 0 && res[x - 1][y] != 0)
            min = Math.min(min, res[x - 1][y]);
        if (x < mat.length - 1)
            min = Math.min(min, dfs(mat, res, x + 1, y));
        if (y > 0 && res[x][y - 1] != 0)
            min = Math.min(min, res[x][y - 1]);
        if (y < mat[0].length - 1)
            min = Math.min(min, dfs(mat, res, x, y + 1));
        return min + 1;
    }
}
