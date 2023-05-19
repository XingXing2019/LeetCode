package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean isBipartite(int[][] graph) {
        int[] colors = new int[graph.length];
        for (int i = 0; i < graph.length; i++) {
            if (colors[i] != 0 || dfs(graph, i, 1, colors))
                continue;
            return false;
        }
        return true;
    }

    public boolean dfs(int[][] graph, int cur, int color, int[] colors){
        if (colors[cur] != 0)
            return colors[cur] == color;
        colors[cur] = color;
        boolean res = true;
        for (int next : graph[cur])
            res = res && dfs(graph, next, color * -1, colors);
        return res;
    }
}
