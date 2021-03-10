package com.company;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class WordDistance {
    Map<String, List<Integer>> map;
    public WordDistance(String[] wordsDict) {
        map = new HashMap<>();
        for (int i = 0; i < wordsDict.length; i++) {
            if (!map.containsKey(wordsDict[i]))
                map.put(wordsDict[i], new LinkedList<>());
            map.get(wordsDict[i]).add(i);
        }
    }

    public int shortest(String word1, String word2) {
        int p1 = 0, p2 = 0, res = Integer.MAX_VALUE;
        List<Integer> index1 = map.get(word1);
        List<Integer> index2 = map.get(word2);
        while (p1 < index1.size() && p2 < index2.size()) {
            res = Math.min(res, Math.abs(index1.get(p1) - index2.get(p2)));
            if (index1.get(p1) > index2.get(p2))
                p2++;
            else
                p1++;
        }
        return res;
    }
}

