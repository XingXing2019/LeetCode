package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        int[] parents = {-1, 2, 0};
        System.out.println(countHighestScoreNodes(parents));
    }

    public static int countHighestScoreNodes(int[] parents) {
        List<Integer>[] graph = new List[parents.length];
        Map<Integer, Integer> scores = new HashMap<>();
        Map<Long, Integer> freq = new HashMap<>();
        for (int i = 0; i < parents.length; i++)
            graph[i] = new ArrayList<>();
        for (int i = 0; i < parents.length; i++) {
            if (parents[i] == -1) continue;
            graph[parents[i]].add(i);
        }
        dfs(0, graph, scores);
        long max = 0;
        for (int i = 0; i < parents.length; i++) {
            long childrenScore = 1;
            long parentScore = i == 0 ? 1 : scores.get(0) - scores.get(i);
            for (int child : graph[i])
                childrenScore *= scores.get(child);
            long score = childrenScore * parentScore;
            max = Math.max(max, score);
            freq.put(score, freq.getOrDefault(score, 0) + 1);
        }
        return freq.get(max);
    }

    public static int dfs(int cur, List<Integer>[] graph, Map<Integer, Integer> scores) {
        int res = 1;
        for (int next : graph[cur])
            res += dfs(next, graph, scores);
        scores.put(cur, res);
        return res;
    }
}
