package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {

    }

    public boolean canCross(int[] stones) {
        HashSet<Integer> stonePos = new HashSet<>();
        for (int stone : stones)
            stonePos.add(stone);
        return dfs(0, 0, stones[stones.length - 1], new int[]{-1, 0, 1}, new HashMap<>(), stonePos);
    }

    public boolean dfs(int pos, int jump, int target, int[] dir, Map<Integer, HashSet<Integer>> failed, HashSet<Integer> stonePos) {
        if (pos == target) return true;
        if (!stonePos.contains(pos)) return false;
        if (failed.containsKey(pos) && failed.get(pos).contains(jump)) return false;
        for (int d : dir) {
            if (jump + d < 1) continue;
            if (dfs(pos + jump + d, jump + d, target, dir, failed, stonePos))
                return true;
        }
        if (!failed.containsKey(pos))
            failed.put(pos, new HashSet<>());
        failed.get(pos).add(jump);
        return false;
    }
}
