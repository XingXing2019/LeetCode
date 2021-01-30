package com.company;

import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] topKFrequent(int[] nums, int k) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int num : nums)
            map.put(num, map.getOrDefault(num, 0) + 1);
        PriorityQueue<Integer> queue = new PriorityQueue<>(Comparator.comparingInt(map::get));
        for (int num : map.keySet()){
            queue.offer(num);
            if(queue.size() > k) queue.poll();
        }
        int[] res = new int[k];
        for (int i = 0; i < res.length; i++)
            res[i] = queue.poll();
        return res;
    }
}
