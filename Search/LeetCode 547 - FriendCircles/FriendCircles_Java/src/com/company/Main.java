package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    int[] parent;
    int[] rank;
    public int findCircleNum(int[][] isConnected) {
        int cities = isConnected.length;
        parent = new int[cities];
        for(int i = 0; i < cities; i++)
            parent[i] = i;
        rank = new int[cities];
        for(int i = 0; i < isConnected.length; i++){
            for (int j = i + 1; j < isConnected.length; j++){
                if(isConnected[i][j] == 0) continue;
                if(union(i, j))
                    cities--;
            }
        }
        return cities;
    }

    public int find(int x){
        if(parent[x] != x)
            parent[x] = find(parent[x]);
        return parent[x];
    }

    public Boolean union(int x, int y){
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
