package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int countServers(int[][] grid) {
        Map<Integer, List<Integer>> rows = new HashMap<>();
        Map<Integer, List<Integer>> cols = new HashMap<>();
        HashSet<Integer> res = new HashSet<>();
        int m = grid.length, n = grid[0].length, max = Math.max(m, n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0)
                    continue;
                if (!rows.containsKey(i))
                    rows.put(i, new ArrayList<>());
                rows.get(i).add(i * max + j);
            }
        }
        for (int j = 0; j < n; j++) {
            for (int i = 0; i < m; i++) {
                if (grid[i][j] == 0)
                    continue;
                if (!cols.containsKey(j))
                    cols.put(j, new ArrayList<>());
                cols.get(j).add(i * max + j);
            }
        }
        for (List<Integer> r : rows.values()) {
            if (r.size() == 1)
                continue;
            res.addAll(r);
        }
        for (List<Integer> c : cols.values()) {
            if (c.size() == 1)
                continue;
            res.addAll(c);
        }
        return res.size();
    }
}
