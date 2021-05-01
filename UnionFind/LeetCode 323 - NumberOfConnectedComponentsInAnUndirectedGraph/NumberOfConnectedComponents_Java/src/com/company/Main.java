package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    int[] parent;
    int[] rank;
    public int countComponents(int n, int[][] edges) {
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
        rank = new int[n];
        for (int[] edge : edges){
            if(union(edge[0], edge[1]))
                n--;
        }
        return n;
    }
    public int find(int x){
        if(parent[x] != x)
            parent[x] = find(parent[x]);
        return parent[x];
    }
    public boolean union(int x, int y){
        int rootX = find(x), rootY = find(y);
        if(rootX == rootY) return false;
        if(rank[rootX] >= rank[rootY]){
            parent[rootY] = rootX;
            if(rank[rootX] == rank[rootY])
                rank[rootX]++;
        }
        else
            parent[rootX] = rootY;
        return true;
    }
}
