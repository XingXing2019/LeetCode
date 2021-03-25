package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int[][] matrix = {{1, 2, 3}, {2, 5, 3}, {7, 1, 5}};
        pacificAtlantic(matrix);
    }

    public static List<List<Integer>> pacificAtlantic(int[][] matrix) {
        List<List<Integer>> res = new ArrayList<>();
        if (matrix.length == 0 || matrix[0].length == 0)
            return res;
        boolean[][] reachPacific = new boolean[matrix.length][matrix[0].length];
        boolean[][] reachAtlantic = new boolean[matrix.length][matrix[0].length];
        int[] dir = {0, 1, 0, -1, 0};
        for (int i = 0; i < matrix.length; i++) {
            reachPacific[i][0] = true;
            reachAtlantic[i][matrix[0].length - 1] = true;
            bfs(matrix, reachPacific, dir, i, 0);
            bfs(matrix, reachAtlantic, dir, i, matrix[0].length - 1);
        }
        for (int i = 0; i < matrix[0].length; i++) {
            reachPacific[0][i] = true;
            reachAtlantic[matrix.length - 1][i] = true;
            bfs(matrix, reachPacific, dir, 0, i);
            bfs(matrix, reachAtlantic, dir, matrix.length - 1, i);
        }
        for (int x = 0; x < matrix.length; x++) {
            for (int y = 0; y < matrix[0].length; y++) {
                if (reachPacific[x][y] && reachAtlantic[x][y]) {
                    List<Integer> pos = new ArrayList<>();
                    pos.add(x);
                    pos.add(y);
                    res.add(pos);
                }
            }
        }
        return res;
    }

    private static void bfs(int[][] matrix, boolean[][] visited, int[] dir, int x, int y) {
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(new int[]{x, y});
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + dir[i];
                int newY = cur[1] + dir[i + 1];
                if (newX < 0 || newX >= matrix.length || newY < 0 || newY >= matrix[0].length)
                    continue;
                if (!visited[newX][newY] && matrix[cur[0]][cur[1]] <= matrix[newX][newY]) {
                    visited[newX][newY] = true;
                    queue.offer(new int[]{newX, newY});
                }
            }
        }
    }
}
