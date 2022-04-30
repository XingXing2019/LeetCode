package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int countUnguarded(int m, int n, int[][] guards, int[][] walls) {
        var map = new int[m][];
        for (int i = 0; i < m; i++)
            map[i] = new int[n];
        for (int[] wall : walls)
            map[wall[0]][wall[1]] = 1;
        int[] dir = {1, 0, -1, 0, 1};
        for (int[] guard : guards) {
            int x = guard[0], y = guard[1];
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < Math.max(m, n); j++) {
                    int newX = x + dir[i] * j, newY = y + dir[i + 1] * j;
                    if (newX < 0 || newX >= m || newY < 0 || newY >= n || map[newX][newY] == 1 || map[x][y] == 3)
                        break;
                    map[newX][newY] = 2;
                }
            }
            map[x][y] = 3;
        }
        var res = 0;
        for (int x = 0; x < m; x++) {
            for (int y = 0; y < n; y++) {
                if (map[x][y] == 0) res++;
            }
        }
        return res;
    }
}
