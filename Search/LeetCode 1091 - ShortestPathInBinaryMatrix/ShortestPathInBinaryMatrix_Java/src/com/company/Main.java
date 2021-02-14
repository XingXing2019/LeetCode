package com.company;

import java.util.ArrayDeque;
import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	    int[][] grid = new int[][]{
	            new int[]{0, 1, 0, 0, 0},
	            new int[]{0, 1, 0, 0, 0},
	            new int[]{0, 0, 0, 0, 1},
	            new int[]{0, 1, 1, 1, 0},
	            new int[]{0, 1, 0, 0, 0}
        };
	    System.out.println(shortestPathBinaryMatrix(grid));
    }
    public static int shortestPathBinaryMatrix(int[][] grid) {
        int n = grid.length;
        if(grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return -1;
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
        ArrayDeque<int[]> queue = new ArrayDeque<>(){{offer(new int[]{0, 0, 1});}};
        boolean[][] visited = new boolean[n][n];
        visited[0][0] = true;
        while (!queue.isEmpty()){
            int[] cur = queue.poll();
            if(cur[0] == n - 1 && cur[1] == n - 1) return cur[2];
            for (int i = 0; i < 8; i++) {
                int newX = dx[i] + cur[0];
                int newY = dy[i] + cur[1];
                if(newX < 0 || newX >= n || newY < 0 || newY >= n) continue;
                if(grid[newX][newY] == 0 && !visited[newX][newY]){
                    visited[newX][newY] = true;
                    queue.offer(new int[]{newX, newY, cur[2] + 1});
                }
            }
        }
        return -1;
    }
}
