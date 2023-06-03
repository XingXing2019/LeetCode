package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int numOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        List<Integer>[] graph = new List[n];
        for (int i = 0; i < n; i++)
            graph[i] = new ArrayList<>();
        for (int i = 0; i < manager.length; i++) {
            if (manager[i] == -1) continue;
            graph[manager[i]].add(i);
        }
        return dfs(graph, headID, informTime);
    }

    public int dfs(List<Integer>[] graph, int cur, int[] informTime){
        if (informTime[cur] == 0)
            return 0;
        var max = 0;
        for (int next : graph[cur])
            max = Math.max(max, dfs(graph, next, informTime));
        return informTime[cur] + max;
    }
}
