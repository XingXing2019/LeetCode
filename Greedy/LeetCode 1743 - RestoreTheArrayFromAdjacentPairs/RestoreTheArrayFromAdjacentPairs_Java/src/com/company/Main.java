package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	    int[][] adjacentPairs = new int[][]{
	            new int[]{2, 1},
	            new int[]{3, 4},
	            new int[]{3, 2},
        };
	    restoreArray(adjacentPairs);
    }
    public static int[] restoreArray(int[][] adjacentPairs) {
        int[] res = new int[adjacentPairs.length + 1];
        int index = 0;
        Map<Integer, List<Integer>> graph = new HashMap<>();
        for (int[] pair : adjacentPairs){
            if(graph.get(pair[0]) == null)
                graph.put(pair[0], new ArrayList<>());
            graph.get(pair[0]).add(pair[1]);
            if(graph.get(pair[1]) == null)
                graph.put(pair[1], new ArrayList<>());
            graph.get(pair[1]).add(pair[0]);
        }
        ArrayDeque<Integer> queue = new ArrayDeque<>();
        HashSet<Integer> set = new HashSet<>();
        for (var kv : graph.entrySet()){
            if(kv.getValue().size() == 1){
                queue.offer(kv.getKey());
                set.add(kv.getKey());
                res[index++] = kv.getKey();
                break;
            }
        }
        while (!queue.isEmpty()){
            int cur = queue.poll();
            for (int next : graph.get(cur)){
                if(set.add(next)){
                    res[index++] = next;
                    queue.offer(next);
                }
            }
        }
        return res;
    }
}
