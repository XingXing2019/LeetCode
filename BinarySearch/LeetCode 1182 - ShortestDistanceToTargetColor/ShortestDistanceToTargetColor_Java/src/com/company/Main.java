package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[] colors = {1, 1, 2, 1, 3, 2, 2, 3, 3};
        int[][] queries = new int[][]{
                new int[]{1, 3},
                new int[]{2, 2},
                new int[]{6, 1}
        };
        System.out.println(shortestDistanceColor(colors, queries));
    }

    public static List<Integer> shortestDistanceColor(int[] colors, int[][] queries) {
        Map<Integer, List<Integer>> map = new HashMap<>();
        for (int i = 0; i < colors.length; i++) {
            if (!map.containsKey(colors[i]))
                map.put(colors[i], new ArrayList<>());
            map.get(colors[i]).add(i);
        }
        List<Integer> res = new ArrayList<>();
        for (int[] query : queries) {
            if (!map.containsKey(query[1])) {
                res.add(-1);
                continue;
            }
            List<Integer> pos = map.get(query[1]);
            int index = binarySearch(pos, query[0]);
            if (index == 0) res.add(pos.get(0) - query[0]);
            else if (index == pos.size()) res.add(query[0] - pos.get(pos.size() - 1));
            else res.add(Math.min(query[0] - pos.get(index - 1), pos.get(index) - query[0]));
        }
        return res;
    }

    private static int binarySearch(List<Integer> pos, int target) {
        int li = 0, hi = pos.size() - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (pos.get(mid) > target)
                hi = mid - 1;
            else
                li = mid + 1;
        }
        return li;
    }
}
