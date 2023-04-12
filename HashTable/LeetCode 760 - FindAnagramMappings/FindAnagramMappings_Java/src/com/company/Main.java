package com.company;

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.Map;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] anagramMappings(int[] nums1, int[] nums2) {
        Map<Integer, Queue<Integer>> map = new HashMap<>();
        int[] res = new int[nums1.length];
        for (int i = 0; i < nums2.length; i++) {
            if (!map.containsKey(nums2[i]))
                map.put(nums2[i], new ArrayDeque<>());
            map.get(nums2[i]).offer(i);
        }
        for (int i = 0; i < nums1.length; i++)
            res[i] = map.get(nums1[i]).poll();
        return res;
    }
}
