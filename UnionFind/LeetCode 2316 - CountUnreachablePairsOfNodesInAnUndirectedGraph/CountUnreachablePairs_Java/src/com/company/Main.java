package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
    }

    int[] parents;
    int[] rank;
    public long countPairs(int n, int[][] edges) {
        parents = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
            parents[i] = i;
        for (int[] e : edges)
            union(e[0], e[1]);
        Map<Integer, Long> map = new HashMap<>();
        long res = 0, sum = n;
        for (int i = 0; i < parents.length; i++) {
            int root = find(parents[i]);
            map.put(root, map.getOrDefault(root, 0L) + 1);
        }
        for (Long count : map.values()) {
            res += count * (sum - count);
            sum -= count;
        }
        return res;
    }

    private int find(int x) {
        if (parents[x] != x)
            parents[x] = find(parents[x]);
        return parents[x];
    }

    private void union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY)
            return;
        if (rank[rootX] < rank[rootY])
            parents[rootX] = rootY;
        else {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        }
    }
}
