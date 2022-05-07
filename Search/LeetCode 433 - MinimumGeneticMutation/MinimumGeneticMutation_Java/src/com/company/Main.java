package com.company;

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        String start = "AACCGGTT", end = "AACCGGTA";
        String[] bank = {"AACCGGTA"};
        System.out.println(minMutation(start, end, bank));
    }

    public static int minMutation(String start, String end, String[] bank) {
        Queue<StringBuilder> queue = new ArrayDeque<>();
        queue.offer(new StringBuilder(start));
        HashSet<String> visited = new HashSet<>();
        visited.add(start);
        HashSet<String> valid = new HashSet<>();
        for (String gene : bank)
            valid.add(gene);
        int res = 0;
        char[] atps = {'A', 'C', 'G', 'T'};
        while (!queue.isEmpty()) {
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                StringBuilder cur = queue.poll();
                if (cur.toString().equals(end))
                    return res;
                for (int j = 0; j < cur.length(); j++) {
                    for (int k = 0; k < atps.length; k++) {
                        if (cur.charAt(j) == atps[k]) continue;
                        StringBuilder next = new StringBuilder(cur.toString());
                        next.setCharAt(j, atps[k]);
                        if (!valid.contains(next.toString()) || !visited.add(next.toString()))
                            continue;
                        queue.offer(next);
                    }
                }
            }
            res++;
        }
        return -1;
    }
}
