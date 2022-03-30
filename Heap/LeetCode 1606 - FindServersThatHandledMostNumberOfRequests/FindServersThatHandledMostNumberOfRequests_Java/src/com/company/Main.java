package com.company;
import java.util.TreeSet;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        TreeSet<Integer> set = new TreeSet<>();
        set.add(1);
        set.add(2);
        set.add(3);
        System.out.println(set.higher(4));
    }

    public static List<Integer> busiestServers(int k, int[] arrival, int[] load) {
        TreeSet<Integer> idleServers = new TreeSet<>();
        for (int i = 0; i < k; i++)
            idleServers.add(i);
        PriorityQueue<int[]> busyServers = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        Map<Integer, Integer> map = new HashMap<>();
        int max = 0;
        for (int i = 0; i < arrival.length; i++) {
            while (!busyServers.isEmpty() && busyServers.peek()[1] <= arrival[i])
                idleServers.add(busyServers.poll()[0]);
            if (idleServers.isEmpty()) continue;
            int server = i % k;
            if (!idleServers.contains(server)) {
                var next = idleServers.higher(server);
                server = next == null ? idleServers.first() : next;
            }
            idleServers.remove(server);
            busyServers.offer(new int[] {server, arrival[i] + load[i]});
            map.put(server, map.getOrDefault(server, 0) + 1);
            max = Math.max(max, map.get(server));
        }
        List<Integer> res = new ArrayList<>();
        for (int server : map.keySet()) {
            if (map.get(server) != max) continue;
            res.add(server);
        }
        return res;
    }
}
