package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int[][] maze = {{0,0,1,0,0}, {0,0,0,0,0}, {0,0,0,1,0}, {1,1,0,1,1}, {0,0,0,0,0}};
        int[] start = {0, 4};
        int[] destination = {4, 4};
        System.out.println(hasPath(maze, start, destination));
    }

    public static boolean hasPath(int[][] maze, int[] start, int[] destination) {
        int[] dir = {1, 0, -1, 0, 1};
        int m = maze.length, n = maze[0].length;
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(new int[]{start[0], start[1]});
        boolean[][] visited = new boolean[m][n];
        visited[start[0]][start[1]] = true;
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            if (cur[0] == destination[0] && cur[1] == destination[1])
                return true;
            for (int i = 0; i < 4; i++) {
                int newX = cur[0], newY = cur[1];
                int x = dir[i], y = dir[i + 1];
                while (newX + x >= 0 && newX + x < m && newY + y >= 0 && newY + y < n && maze[newX + x][newY + y] == 0) {
                    newX += x;
                    newY += y;
                }
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || maze[newX][newY] == 1 || visited[newX][newY]) continue;
                visited[newX][newY] = true;
                queue.offer(new int[]{newX, newY});
            }
        }
        return false;
    }
}
