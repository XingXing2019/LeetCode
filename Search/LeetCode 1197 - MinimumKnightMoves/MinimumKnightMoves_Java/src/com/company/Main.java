package com.company;

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minKnightMoves(int x, int y) {
        int[][] dir = {{-2, 1}, {-1, 2}, {1, 2}, {2, 1}, {2, -1}, {1, -2}, {-1, -2}, {-2, -1}};
        Queue<int[]> queue = new ArrayDeque<>();
        HashSet<String> visited = new HashSet<>();
        queue.offer(new int[]{0, 0, 0});
        visited.add("0:0");
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            if (cur[0] == x && cur[1] == y) return cur[2];
            for (int i = 0; i < dir.length; i++) {
                int nextX = cur[0] + dir[i][0];
                int nextY = cur[1] + dir[i][1];
                if(visited.add(nextX + ":" + nextY))
                    queue.offer(new int[]{nextX, nextY, cur[2] + 1});
            }
        }
        return -1;
    }
}
