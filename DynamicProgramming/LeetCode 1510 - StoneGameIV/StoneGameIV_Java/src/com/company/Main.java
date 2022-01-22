package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean winnerSquareGame(int n) {
        return dfs(n, 0, new HashMap<>());
    }

    public static Boolean dfs(int n, int turn, Map<String, Boolean> dp) {
        var key = n + ":" + turn;
        if (n == 0) {
            dp.put(key, turn % 2 != 0);
            return dp.get(key);
        }
        if (dp.containsKey(key)) return dp.get(key);
        var max = (int) Math.sqrt(n);
        if (turn % 2 == 0) {
            for (int i = max; i >= 1; i--) {
                if (dfs(n - i * i, turn + 1, dp)) {
                    dp.put(key, true);
                    return true;
                }
            }
            dp.put(key, false);
        } else {
            for (int i = max; i >= 1; i--) {
                if (!dfs(n - i * i, turn + 1, dp)) {
                    dp.put(key, false);
                    return false;
                }
            }
            dp.put(key, true);
        }
        return dp.get(key);
    }
}
