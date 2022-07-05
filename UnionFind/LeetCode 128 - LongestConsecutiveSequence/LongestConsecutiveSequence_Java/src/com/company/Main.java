package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        int[] nums = {100,4,200,1,3,2};
        System.out.println(longestConsecutive(nums));
    }

    static Map<Integer, Integer> parents;
    static Map<Integer, Integer> rank;
    public static int longestConsecutive(int[] nums) {
        parents = new HashMap<>();
        rank = new HashMap<>();
        for (int num : nums) {
            if (parents.containsKey(num))
                continue;
            parents.put(num, num);
            rank.put(num, 0);
        }
        for (int num : nums) {
            if (parents.containsKey(num - 1))
                union(num - 1, num);
            if (parents.containsKey(num + 1))
                union(num, num + 1);
        }
        for (int num : nums)
            find(num);
        int res = 0;
        Map<Integer, Integer> freq = new HashMap<>();
        for (int value : parents.values()) {
            freq.put(value, freq.getOrDefault(value, 0) + 1);
            res = Math.max(res, freq.get(value));
        }
        return res;
    }

    private static int find(int x) {
        if (parents.get(x) != x) {
            var parent = find(parents.get(x));
            parents.put(x, parent);
        }
        return parents.get(x);
    }

    private static void union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY) return;
        if (rank.get(rootX) < rank.get(rootY))
            parents.put(rootX, rootY);
        else {
            parents.put(rootY, rootX);
            if (rank.get(rootX) == rank.get(rootY))
                rank.put(rootX, rank.get(rootX) + 1);
        }
    }
}
