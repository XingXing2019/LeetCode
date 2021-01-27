package com.company;

import java.util.ArrayDeque;
import java.util.function.BiFunction;

public class Main {

    public static void main(String[] args) {
        int[][] heights = new int[][]{
                new int[]{1, 2, 2},
                new int[]{3, 8, 2},
                new int[]{5, 3, 5},
        };
        System.out.println(minimumEffortPath(heights));
    }

    public static int minimumEffortPath(int[][] heights) {
        int min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
        for (int i = 0; i < heights.length; i++) {
            for (int j = 0; j < heights[0].length; j++) {
                min = Math.min(min, heights[i][j]);
                max = Math.max(max, heights[i][j]);
            }
        }
        int li = 0, hi = max - min;
        while (li < hi){
            int[][] visited = new int[heights.length][heights[0].length];
            int mid = li + (hi - li) / 2;
            if(dfs(heights, visited, 0, 0, heights[0][0], mid)) hi = mid;
            else li = mid + 1;
        }
        return li;
    }

    public static boolean bfs(int[][] heights, int threshold){
        int[][] visited = new int[heights.length][];
        for (int i = 0; i < visited.length; i++)
            visited[i] = new int[heights[0].length];
        visited[0][0] = 1;
        ArrayDeque<int[]> queue = new ArrayDeque<>(){{offer(new int[]{0, 0});}};
        int[] dx = {-1, 1, 0, 0};
        int[] dy = {0, 0, -1, 1};
        while (!queue.isEmpty()){
            int[] cur = queue.poll();
            if(cur[0] == heights.length - 1 && cur[1] == heights[0].length - 1)
                return true;
            for (int i = 0; i < 4; i++) {
                int newX = dx[i] + cur[0];
                int newY = dy[i] + cur[1];
                if(newX < 0 || newX >= heights.length || newY < 0 || newY >= heights[0].length)
                    continue;
                if(visited[newX][newY] == 0 && Math.abs(heights[newX][newY] - heights[cur[0]][cur[1]]) <= threshold){
                    queue.offer(new int[]{newX, newY});
                    visited[newX][newY] = 1;
                }
            }
        }
        return false;
    }

    public static boolean dfs(int[][] heights, int[][] visited, int x, int y, int cur, int threshold){
        if(x < 0 || x >= heights.length || y < 0 || y >= heights[0].length || visited[x][y] == 1 || Math.abs(cur - heights[x][y]) > threshold)
            return false;
        if(x == heights.length - 1 && y == heights[0].length - 1)
            return true;
        visited[x][y] = 1;
        if(dfs(heights, visited, x + 1, y, heights[x][y], threshold)) return true;
        if(dfs(heights, visited, x - 1, y, heights[x][y], threshold)) return true;
        if(dfs(heights, visited, x, y + 1, heights[x][y], threshold)) return true;
        if(dfs(heights, visited, x, y - 1, heights[x][y], threshold)) return true;
        return false;
    }
}
