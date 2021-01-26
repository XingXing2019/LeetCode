package com.company;

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] topKFrequent(int[] nums, int k) {
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int num : nums){
            if(!map.containsKey(num))
                map.put(num, 1);
            else
                map.put(num, map.get(num) + 1);
        }
        PriorityQueue<Integer> queue = new PriorityQueue<>();
        for (var kv : map.entrySet()){
            if(queue.size() < k)
                queue.offer(kv.getValue());
            else if (kv.getValue() > queue.peek()){
                queue.poll();
                queue.offer(kv.getValue());
            }
        }
        int[] res = new int[k];
        int index = 0;
        for (var kv : map.entrySet()){
            if(kv.getValue() >= queue.peek())
                res[index++] = kv.getKey();
        }
        return res;
    }
}
