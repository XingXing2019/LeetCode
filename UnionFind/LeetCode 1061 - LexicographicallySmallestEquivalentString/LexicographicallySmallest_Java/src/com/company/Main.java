package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        String s1 = "parker", s2 = "morris", baseStr = "parser";
        System.out.println(smallestEquivalentString(s1, s2, baseStr));
    }

    static int[] parents;
    static int[] ranks;

    public static String smallestEquivalentString(String s1, String s2, String baseStr) {
        parents = new int[26];
        ranks = new int[26];
        Map<Integer, List<Integer>> map = new HashMap<>();
        Map<Integer, Integer> pattern = new HashMap<>();
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            parents[i] = i;
            map.put(i, new ArrayList<>());
            pattern.put(i, i);
        }
        for (int i = 0; i < s1.length(); i++) {
            int x = s1.charAt(i) - 'a', y = s2.charAt(i) - 'a';
            union(x, y);
        }
        for (int i = 0; i < 26; i++)
            map.get(find(parents[i])).add(i);
        for (List<Integer> letters : map.values()) {
            if (letters.size() <= 1) continue;
            Collections.sort(letters);
            for (Integer letter : letters)
                pattern.put(letter, letters.get(0));
        }
        for (int i = 0; i < baseStr.length(); i++) {
            var letter = (int) pattern.get(baseStr.charAt(i) - 'a');
            res.append((char) (letter + 'a'));
        }
        return res.toString();
    }

    public static int find(int x) {
        if (parents[x] != x)
            parents[x] = find(parents[x]);
        return parents[x];
    }

    public static void union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY)
            return;
        if (ranks[rootX] >= ranks[rootY]) {
            parents[rootY] = rootX;
            if (ranks[rootX] == ranks[rootY])
                ranks[rootX]++;
        } else
            parents[rootX] = rootY;
    }
}
