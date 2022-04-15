package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[][] grid = {{1, 0}, {0, 1}};
        System.out.println(largestIsland(grid));
    }

    public static int largestIsland(int[][] grid) {
        int id = 2, res = 0;
        Map<Integer, List<int[]>> edges = new HashMap<>();
        Map<Integer, Integer> map = new HashMap<>();
        map.put(0, 0);
        for (int x = 0; x < grid.length; x++) {
            for (int y = 0; y < grid[0].length; y++) {
                if (grid[x][y] != 1) continue;
                edges.put(id, new ArrayList<>());
                int area = dfs(grid, x, y, id, edges);
                map.put(id, area);
                id++;
            }
        }
        if (id == 2) return 1;
        int[] dir = {1, 0, -1, 0, 1};
        for (List<int[]> waters : edges.values()) {
            for (int[] water : waters) {
                HashSet<Integer> surrounding = new HashSet<>();
                for (int i = 0; i < 4; i++) {
                    int x = water[0] + dir[i], y = water[1] + dir[i + 1];
                    if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length) continue;
                    surrounding.add(grid[x][y]);
                }
                int area = 1;
                for (int island : surrounding)
                    area += map.get(island);
                res = Math.max(res, area);
            }
        }
        return res == 0 ? grid.length * grid[0].length : res;
    }

    public static int dfs(int[][] grid, int x, int y, int id, Map<Integer, List<int[]>> edges) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] == id)
            return 0;
        if (grid[x][y] == 0) {
            edges.get(id).add(new int[]{x, y});
            return 0;
        }
        int res = 1;
        grid[x][y] = id;
        res += dfs(grid, x + 1, y, id, edges);
        res += dfs(grid, x - 1, y, id, edges);
        res += dfs(grid, x, y + 1, id, edges);
        res += dfs(grid, x, y - 1, id, edges);
        return res;
    }
}
