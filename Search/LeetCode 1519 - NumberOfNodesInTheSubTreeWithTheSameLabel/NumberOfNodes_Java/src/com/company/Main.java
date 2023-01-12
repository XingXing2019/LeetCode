package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	    int n = 7;
	    int[][] edges = {{0, 1}, {0, 2}, {1, 4}, {1, 5}, {2, 3}, {2, 6} };
	    String labels = "abaedcd";
        System.out.println(countSubTrees(n, edges, labels));
    }

    public static int[] countSubTrees(int n, int[][] edges, String labels) {
        List<Integer>[] graph = new List[n];
        int[] res = new int[n];
        for (int i = 0; i < n; i++)
            graph[i] = new ArrayList<>();
        for (int[] edge : edges) {
            graph[edge[0]].add(edge[1]);
            graph[edge[1]].add(edge[0]);
        }
        HashSet<Integer> visited = new HashSet<>();
        visited.add(0);
        dfs(graph, 0, visited, labels, res);
        return res;
    }

    public static int[] dfs(List<Integer>[] graph, int cur, HashSet<Integer> visited, String labels, int[] res) {
        int[] freq = new int[26];
        freq[labels.charAt(cur) - 'a']++;
        for (int next : graph[cur]) {
            if (!visited.add(next)) continue;
            int[] children = dfs(graph, next, visited, labels, res);
            for (int i = 0; i < 26; i++)
                freq[i] += children[i];
        }
        res[cur] = freq[labels.charAt(cur) - 'a'];
        return freq;
    }
}
