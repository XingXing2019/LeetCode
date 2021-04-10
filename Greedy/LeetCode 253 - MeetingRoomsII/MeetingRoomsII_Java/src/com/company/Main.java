package com.company;

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int minMeetingRooms(int[][] intervals) {
        Map<Integer, Integer> timestamps = new HashMap<>();
        for (int[] interval : intervals){
            timestamps.put(interval[0], timestamps.getOrDefault(interval[0], 0) + 1);
            timestamps.put(interval[1], timestamps.getOrDefault(interval[1], 0) - 1);
        }
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[0] - b[0]);
        for (int key : timestamps.keySet())
            heap.offer(new int[]{key, timestamps.get(key)});
        int res = 0, sum = 0;
        while (!heap.isEmpty()){
            sum += heap.poll()[1];
            res = Math.max(res, sum);
        }
        return res;
    }
}
