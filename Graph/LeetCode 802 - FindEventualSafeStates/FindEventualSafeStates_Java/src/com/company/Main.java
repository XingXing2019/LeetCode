package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public List<Integer> eventualSafeNodes(int[][] graph) {
        int[] outDegree = new int[graph.length];
        List<Integer>[] map = new List[graph.length];
        Queue<Integer> queue = new ArrayDeque<>();
        List<Integer> res = new ArrayList<>();
        for (int i = 0; i < graph.length; i++)
            map[i] = new ArrayList<>();
        for (int i = 0; i < graph.length; i++) {
            outDegree[i] = graph[i].length;
            if (outDegree[i] == 0)
                queue.offer(i);
            for (int j = 0; j < graph[i].length; j++)
                map[graph[i][j]].add(i);
        }
        while (!queue.isEmpty()){
            int cur = queue.poll();
            res.add(cur);
            for (int next : map[cur]){
                outDegree[next]--;
                if(outDegree[next] == 0)
                    queue.offer(next);
            }
        }
        Collections.sort(res);
        return res;
    }
}
