package com.company;

import java.util.HashSet;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[][] grid = {{0, 2}, {1, 3}};
        System.out.println(swimInWater(grid));
    }

    public static int swimInWater(int[][] grid) {
        int n = grid.length;
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[2] - b[2]);
        heap.offer(new int[]{0, 0, grid[0][0]});
        int[] dir = {1, 0, -1, 0, 1};
        boolean[][] visited = new boolean[n][n];
        visited[0][0] = true;
        while (!heap.isEmpty()) {
            int[] cur = heap.poll();
            boolean added = false;
            if (cur[0] == n - 1 && cur[1] == n - 1)
                return cur[2];
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + dir[i];
                int newY = cur[1] + dir[i + 1];
                if (newX < 0 || newX >= n || newY < 0 || newY >= n)
                    continue;
                if (cur[2] < grid[newX][newY] && !added) {
                    heap.offer(new int[]{cur[0], cur[1], cur[2] + 1});
                    added = true;
                } else if (cur[2] >= grid[newX][newY] && !visited[newX][newY]) {
                    heap.offer(new int[]{newX, newY, cur[2]});
                    visited[newX][newY] = true;
                }
            }
        }
        return -1;
    }
}
