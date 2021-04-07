package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class FirstUnique {
    Queue<Integer> queue;
    Map<Integer, Integer> map;
    HashSet<Integer> set;

    public FirstUnique(int[] nums) {
        map = new HashMap<>();
        set = new HashSet<>();
        queue = new ArrayDeque<>();
        for (int num : nums) {
            if (set.contains(num)) continue;
            queue.offer(num);
            map.put(num, map.getOrDefault(num, 0) + 1);
            if (map.get(num) > 1) {
                set.add(num);
                map.remove(num);
            }
        }
    }

    public int showFirstUnique() {
        while (!queue.isEmpty() && set.contains(queue.peek()))
            queue.poll();
        return queue.isEmpty() ? -1 : queue.peek();
    }

    public void add(int value) {
        if (set.contains(value)) return;
        queue.offer(value);
        map.put(value, map.getOrDefault(value, 0) + 1);
        if (map.get(value) > 1) {
            set.add(value);
            map.remove(value);
        }
    }
}
