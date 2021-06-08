package com.company;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int[][] maze = new int[][]{
                new int[]{0, 0, 1, 0, 0},
                new int[]{0, 0, 0, 0, 0},
                new int[]{0, 0, 0, 1, 0},
                new int[]{1, 1, 0, 1, 1},
                new int[]{0, 0, 0, 0, 0},
        };
        int[] start = {0, 4}, destination = {4, 4};
        System.out.println(shortestDistance(maze, start, destination));
    }

    public static int shortestDistance(int[][] maze, int[] start, int[] destination) {
        int[] dx = {-1, 1, 0, 0}, dy = {0, 0, -1, 1};
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(start);
        int[][] distance = new int[maze.length][maze[0].length];
        for (int i = 0; i < distance.length; i++)
            Arrays.fill(distance[i], Integer.MAX_VALUE);
        distance[start[0]][start[1]] = 0;
        while (!queue.isEmpty()){
            int[] cur = queue.poll();
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + dx[i];
                int newY = cur[1] + dy[i];
                int len = 0;
                while (newX >= 0 && newX < maze.length && newY >= 0 && newY < maze[0].length && maze[newX][newY] == 0){
                    newX += dx[i];
                    newY += dy[i];
                    len++;
                }
                if(distance[cur[0]][cur[1]] + len < distance[newX - dx[i]][newY - dy[i]]){
                    distance[newX - dx[i]][newY - dy[i]] = distance[cur[0]][cur[1]] + len;
                    queue.offer(new int[]{newX - dx[i], newY - dy[i]});
                }
            }
        }
        return distance[destination[0]][destination[1]] == Integer.MAX_VALUE ? -1 : distance[destination[0]][destination[1]];
    }
}
