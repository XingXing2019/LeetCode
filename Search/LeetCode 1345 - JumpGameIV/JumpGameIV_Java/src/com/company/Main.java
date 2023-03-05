package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[] arr = {100, -23, -23, 404, 100, 23, 23, 23, 3, 404};
        System.out.println(minJumps(arr));
    }

    public static int minJumps(int[] arr) {
        Map<Integer, List<Integer>> graph = new HashMap<>();
        for (int i = 0; i < arr.length; i++) {
            if (!graph.containsKey(arr[i]))
                graph.put(arr[i], new ArrayList<>());
            graph.get(arr[i]).add(i);
        }
        Queue<int[]> queue = new ArrayDeque<>();
        HashSet<Integer> visited = new HashSet<>();
        queue.offer(new int[]{0, 0});
        visited.add(0);
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            if (cur[0] == arr.length - 1)
                return cur[1];
            if (graph.containsKey(arr[cur[0]])) {
                for (int next : graph.get(arr[cur[0]])) {
                    if (!visited.add(next)) continue;
                    queue.offer(new int[]{next, cur[1] + 1});
                }
            }
            graph.remove(arr[cur[0]]);
            if (cur[0] != 0 && visited.add(cur[0] - 1))
                queue.offer(new int[]{cur[0] - 1, cur[1] + 1});
            if (cur[0] != arr.length - 1 && visited.add(cur[0] + 1))
                queue.offer(new int[]{cur[0] + 1, cur[1] + 1});
        }
        return -1;
    }
}
