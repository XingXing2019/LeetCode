package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    class Node {
        String name;
        double val;
        public Node(String name, double val) {
            this.name = name;
            this.val = val;
        }
    }
    double res;
    public double[] calcEquation(List<List<String>> equations, double[] values, List<List<String>> queries) {
        Map<String, List<Node>> graph = new HashMap<>();
        for (int i = 0; i < equations.size(); i++) {
            String first = equations.get(i).get(0);
            String second = equations.get(i).get(1);
            if (!graph.containsKey(first))
                graph.put(first, new ArrayList<>());
            graph.get(first).add(new Node(second, values[i]));
            if (!graph.containsKey(second))
                graph.put(second, new ArrayList<>());
            graph.get(second).add(new Node(first, 1 / values[i]));
        }
        double[] ans = new double[queries.size()];
        for (int i = 0; i < queries.size(); i++) {
            res = -1;
            String start = queries.get(i).get(0);
            String target = queries.get(i).get(1);
            dfs(graph, start, target, 1, new HashSet<>());
            ans[i] = res;
        }
        return ans;
    }

    public void dfs(Map<String, List<Node>> graph, String start, String target, double path, HashSet<String> visited) {
        if (!visited.add(start) || !graph.containsKey(start)) return;
        if (start.equals(target)) res = path;
        for (Node next : graph.get(start)) {
            dfs(graph, next.name, target, path * next.val, visited);
        }
    }
}
