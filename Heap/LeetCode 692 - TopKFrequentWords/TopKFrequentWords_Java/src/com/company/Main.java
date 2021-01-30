package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<String> topKFrequent(String[] words, int k) {
        HashMap<String, Integer> map = new HashMap<>();
        for (String word : words)
            map.put(word, map.getOrDefault(word, 0) + 1);
        PriorityQueue<String> heap = new PriorityQueue<>((w1, w2) ->
                map.get(w1) == map.get(w2) ? w2.compareTo(w1) : map.get(w1) - map.get(w2));
        for (String word : map.keySet()){
            heap.offer(word);
            if(heap.size() > k) heap.poll();
        }
        List<String> res = new ArrayList<>();
        while (!heap.isEmpty()) res.add(heap.poll());
        Collections.reverse(res);
        return res;
    }
}
