package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean canReach_BFS(int[] arr, int start) {
        ArrayList<Integer> graph[] = new ArrayList[arr.length];
        for (int i = 0; i < arr.length; i++){
            if(graph[i] == null) graph[i] = new ArrayList<>();
            if(i + arr[i] < arr.length) graph[i].add(i + arr[i]);
            if(i - arr[i] >= 0) graph[i].add(i - arr[i]);
        }
        ArrayDeque<Integer> queue = new ArrayDeque<>(){{offer(start);}};
        HashSet<Integer> visited = new HashSet<>(){{add(start);}};
        while (!queue.isEmpty()){
            var cur = queue.poll();
            if(arr[cur] == 0) return true;
            for (int next : graph[cur]){
                if(visited.add(next))
                    queue.offer(next);
            }
        }
        return false;
    }

    public boolean canReach_DFS(int[] arr, int start) {
        return dfs(arr, start, new HashSet<>());
    }

    public boolean dfs(int[] arr, int cur, HashSet<Integer> visited){
        if(cur >= arr.length || cur < 0 || visited.contains(cur)) return false;
        if(arr[cur] == 0) return true;
        visited.add(cur);
        return dfs(arr, cur - arr[cur], visited) || dfs(arr, cur + arr[cur], visited);
    }
}
