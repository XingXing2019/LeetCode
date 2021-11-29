package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<List<String>> accountsMerge(List<List<String>> accounts) {
        var graph = new HashMap<String, HashSet<String>>();
        var names = new HashMap<String, String>();
        for (List<String> account : accounts) {
            for (int i = 1; i < account.size(); i++) {
                if (!graph.containsKey(account.get(i)))
                    graph.put(account.get(i), new HashSet<>());
                graph.get(account.get(i)).addAll(account);
                graph.get(account.get(i)).remove(account.get(0));
                names.put(account.get(i), account.get(0));
            }
        }
        var visited = new HashSet<String>();
        var res = new ArrayList<List<String>>();
        for (String email : graph.keySet()) {
            if (!visited.add(email)) continue;
            Queue<String> queue = new ArrayDeque<>();
            queue.offer(email);
            var temp = new ArrayList<String>();
            while (!queue.isEmpty()) {
                var cur = queue.poll();
                temp.add(cur);
                for (var next : graph.get(cur)) {
                    if (!visited.add(next)) continue;
                    queue.offer(next);
                }
            }
            temp.sort((a, b) -> a.compareTo(b));
            temp.add(0, names.get(temp.get(0)));
            res.add(temp);
        }
        return res;
    }
}
