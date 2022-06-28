package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    int[] parents;
    int[] rank;
    public int makeConnected(int n, int[][] connections) {
        parents = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
            parents[i] = i;
        int surplus = 0, groups = n;
        for (var c : connections) {
            if (union(c[0], c[1]))
                groups--;
            else
                surplus++;
        }
        return surplus < groups - 1 ? -1 : Math.min(surplus, groups - 1);
    }

    private boolean union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY)
            return false;
        if (rank[rootX] < rank[rootY])
            parents[rootX] = parents[rootY];
        else {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        }
        return true;
    }

    private int find(int x) {
        if (parents[x] != x)
            parents[x] = find(parents[x]);
        return parents[x];
    }
}
