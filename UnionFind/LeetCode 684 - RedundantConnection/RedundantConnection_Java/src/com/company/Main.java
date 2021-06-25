package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    int[] parents;
    int[] rank;

    public int[] findRedundantConnection(int[][] edges) {
        parents = new int[edges.length];
        rank = new int[edges.length];
        for (int i = 0; i < parents.length; i++)
            parents[i] = i;
        for (int[] edge : edges) {
            if (!Union(edge[0] - 1, edge[1] - 1))
                return edge;
        }
        return null;
    }

    private int Find(int x) {
        if (parents[x] != x)
            parents[x] = Find(parents[x]);
        return parents[x];
    }

    private boolean Union(int x, int y) {
        int rootX = Find(x), rootY = Find(y);
        if (rootX == rootY) return false;
        if (rank[rootX] >= rank[rootY]) {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        } else
            parents[rootX] = rootY;
        return true;
    }
}
