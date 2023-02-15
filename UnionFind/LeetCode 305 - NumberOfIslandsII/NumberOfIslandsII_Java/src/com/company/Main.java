package com.company;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int m = 3, n = 3;
        int[][] positions = {{0, 0}, {0, 1}, {1, 2}, {2, 1}};
        System.out.println(numIslands2(m, n, positions));
    }

    static int[] parents;
    static int[] rank;

    public static List<Integer> numIslands2(int m, int n, int[][] positions) {
        parents = new int[m * n];
        rank = new int[m * n];
        var count = 0;
        for (int i = 0; i < parents.length; i++)
            parents[i] = i;
        HashSet<Integer> visited = new HashSet<>();
        List<Integer> res = new ArrayList<>();
        int[] dir = {1, 0, -1, 0, 1};
        for (int[] pos : positions) {
            int x = pos[0], y = pos[1];
            if (!visited.add(x * n + y)) {
                res.add(count);
                continue;
            }
            count++;
            for (int i = 0; i < 4; i++) {
                int newX = x + dir[i], newY = y + dir[i + 1];
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || !visited.contains(newX * n + newY)) continue;
                if (union(x * n + y, newX * n + newY))
                    count--;
            }
            res.add(count);
        }
        return res;
    }

    public static int find(int x) {
        if (parents[x] != x)
            parents[x] = find(parents[x]);
        return parents[x];
    }

    public static boolean union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY) return false;
        if (rank[rootX] < rank[rootY])
            parents[rootX] = rootY;
        else {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        }
        return true;
    }
}
