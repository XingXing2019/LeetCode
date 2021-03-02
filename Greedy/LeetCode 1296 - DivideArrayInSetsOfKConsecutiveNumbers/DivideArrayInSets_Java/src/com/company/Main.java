package com.company;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] nums = {3, 3, 2, 2, 1, 1};
        int k = 3;
        System.out.println(isPossibleDivide(nums, k));
    }

    public static boolean isPossibleDivide(int[] nums, int k) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int num : nums)
            map.put(num, map.getOrDefault(num, 0) + 1);
        int[][] record = new int[map.size()][];
        int index = 0;
        for (int key : map.keySet())
            record[index++] = new int[]{key, map.get(key)};
        Arrays.sort(record, (a, b) -> a[0] - b[0]);
        for (int i = 0; i < record.length; i++) {
            if(record[i][1] == 0) continue;
            int first = record[i][0], count = record[i][1];
            for (int j = 0; j < k; j++) {
                if(i + j >= record.length || first + j != record[i + j][0] || record[i + j][1] - count < 0)
                    return false;
                record[i + j][1] -= count;
            }
        }
        return true;
    }
}
