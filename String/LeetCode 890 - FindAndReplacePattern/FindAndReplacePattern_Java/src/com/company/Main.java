package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<String> findAndReplacePattern(String[] words, String pattern) {
        List<String> res = new ArrayList<>();
        for (String word : words) {
            if (!isMatch(word, pattern)) continue;
            res.add(word);
        }
        return res;
    }

    public boolean isMatch(String word, String pattern) {
        Map<Character, Character> map1 = new HashMap<>();
        Map<Character, Character> map2 = new HashMap<>();
        for (int i = 0; i < word.length(); i++) {
            char c1 = word.charAt(i);
            char c2 = pattern.charAt(i);
            if (map1.containsKey(c1) && !map1.get(c1).equals(c2))
                return false;
            if (map2.containsKey(c2) && !map2.get(c2).equals(c1))
                return false;
            map1.put(c1, c2);
            map2.put(c2, c1);
        }
        return true;
    }
}
