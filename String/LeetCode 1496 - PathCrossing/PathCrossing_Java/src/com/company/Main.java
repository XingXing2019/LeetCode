package com.company;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isPathCrossing(String path) {
        Map<Character, int[]> dir = new HashMap<>();
        dir.put('N', new int[]{-1, 0});
        dir.put('S', new int[]{1, 0});
        dir.put('W', new int[]{0, -1});
        dir.put('E', new int[]{0, 1});
        HashSet<String> visited = new HashSet<>();
        visited.add("0:0");
        int x = 0, y = 0;
        for (int i = 0; i < path.length(); i++) {
            x += dir.get(path.charAt(i))[0];
            y += dir.get(path.charAt(i))[1];
            if(!visited.add(x + ":" + y))
                return true;
        }
        return false;
    }
}
