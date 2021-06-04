package com.company;

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int openLock(String[] deadends, String target) {
        HashSet<String> set = new HashSet<>();
        HashSet<String> visited = new HashSet<>();
        for (String deadend : deadends)
            set.add(deadend);
        if (set.contains("0000")) return -1;
        Queue<String> queue = new ArrayDeque<>();
        visited.add("0000");
        queue.offer("0000");
        int res = 0;
        while (!queue.isEmpty()) {
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                String cur = queue.poll();
                if (cur.equals(target)) return res;
                for (int j = 0; j < 4; j++) {
                    int digit = cur.charAt(j) - '0';
                    int up = digit == 9 ? 0 : digit + 1;
                    int down = digit == 0 ? 9 : digit - 1;
                    String str1 = cur.substring(0, j) + up + cur.substring(j + 1);
                    String str2 = cur.substring(0, j) + down + cur.substring(j + 1);
                    if(!set.contains(str1) && visited.add(str1))
                        queue.offer(str1);
                    if(!set.contains(str2) && visited.add(str2))
                        queue.offer(str2);
                }
            }
            res++;
        }
        return -1;
    }
}
