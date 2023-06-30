package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int row = 3, col = 3;
        int[][] cells = {{1, 2}, {2, 1}, {3, 3}, {2, 2}, {1, 1}, {1, 3}, {2, 3}, {3, 2}, {3, 1}};
        System.out.println(latestDayToCross(row, col, cells));
    }

    public static int latestDayToCross(int row, int col, int[][] cells) {
        int li = 0, hi = cells.length - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            int[][] map = new int[row][col];
            for (int i = 0; i <= mid; i++)
                map[cells[i][0] - 1][cells[i][1] - 1] = 1;
            boolean canPass = false;
            for (int y = 0; y < col; y++) {
                if (map[0][y] == 1 || !bfs(map, 0, y)) continue;
                canPass = true;
                break;
            }
            if (canPass)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return li;
    }

    public static boolean bfs(int[][] map, int x, int y) {
        int row = map.length, col = map[0].length;
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(new int[]{x, y});
        boolean[][] visited = new boolean[row][col];
        visited[x][y] = true;
        int[] dir = {1, 0, -1, 0, 1};
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            if (cur[0] == row - 1)
                return true;
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                if (newX < 0 || newX >= row || newY < 0 || newY >= col || map[newX][newY] == 1 || visited[newX][newY])
                    continue;
                visited[newX][newY] = true;
                queue.offer(new int[]{newX, newY});
            }
        }
        return false;
    }
}
