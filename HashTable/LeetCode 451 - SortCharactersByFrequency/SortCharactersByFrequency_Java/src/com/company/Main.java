package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String frequencySort_pq(String s) {
        Map<Character, Integer> map = new HashMap<>();
        for (Character c : s.toCharArray())
            map.put(c, map.getOrDefault(c, 0) + 1);
        PriorityQueue<Character> heap = new PriorityQueue<>((a, b) -> map.get(b) - map.get(a));
        for (Character c : map.keySet())
            heap.offer(c);
        StringBuilder res = new StringBuilder();
        while (!heap.isEmpty()) {
            Character c = heap.poll();
            for (int i = 0; i < map.get(c); i++)
                res.append(c);
        }
        return res.toString();
    }

    public String frequencySort(String s) {
        Map<Character, Integer> map = new HashMap<>();
        int max = 0;
        for (Character c : s.toCharArray()) {
            map.put(c, map.getOrDefault(c, 0) + 1);
            max = Math.max(max, map.get(c));
        }
        List<Character>[] freq = new List[max + 1];
        for (Character c : map.keySet()){
            if (freq[map.get(c)] == null)
                freq[map.get(c)] = new ArrayList<>();
            freq[map.get(c)].add(c);
        }
        StringBuilder res = new StringBuilder();
        for (int i = max; i >= 0; i--) {
            if (freq[i] == null) continue;
            for (Character c : freq[i]){
                for (int j = 0; j < i; j++)
                    res.append(c);
            }
        }
        return res.toString();
    }
}