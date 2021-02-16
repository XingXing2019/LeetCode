package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<Integer> killProcess(List<Integer> pid, List<Integer> ppid, int kill) {
        Map<Integer, List<Integer>> graph = new HashMap<>();
        for (int i = 0; i < ppid.size(); i++) {
            if(!graph.containsKey(ppid.get(i)))
                graph.put(ppid.get(i), new ArrayList<>());
            graph.get(ppid.get(i)).add(pid.get(i));
        }
        ArrayDeque<Integer> queue = new ArrayDeque<>(){{offer(kill);}};
        List<Integer> res = new ArrayList<>();
        while (!queue.isEmpty()){
            int cur = queue.poll();
            res.add(cur);
            if(!graph.containsKey(cur)) continue;
            for (int next : graph.get(cur))
                queue.offer(next);
        }
        return res;
    }
}
