package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<List<Integer>> allPathsSourceTarget(int[][] graph) {
        List<List<Integer>> res = new ArrayList<>();
        dfs(graph, 0, new ArrayList<>(), res);
        return res;
    }

    public void dfs(int[][] graph, int cur, List<Integer> path, List<List<Integer>> res) {
        path.add(cur);
        if (cur == graph.length - 1) {
            res.add(new ArrayList<>(path));
            return;
        }
        for (Integer next : graph[cur]) {
            dfs(graph, next, path, res);
            path.remove(path.size() - 1);
        }
    }
}
