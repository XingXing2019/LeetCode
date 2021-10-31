package com.company;

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.PriorityQueue;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minimumOperations(int[] nums, int start, int goal) {
        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(start);
        HashSet<Integer> visited = new HashSet<>();
        int res = 0;
        while (!queue.isEmpty()) {
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                int cur = queue.poll();
                if (cur == goal) return res;
                if (cur < 0 || cur > 1000 || !visited.add(cur)) continue;
                for (int num : nums) {
                    queue.offer(cur + num);
                    queue.offer(cur - num);
                    queue.offer(cur ^ num);
                }
            }
            res++;
        }
        return -1;
    }
}
