package com.company;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        String pattern = "abba", s = "dog cat cat dog";
        System.out.println(wordPattern(pattern, s));
    }

    public static boolean wordPattern(String pattern, String s) {
        Map<Character, String> map = new HashMap<>();
        HashSet<String> seen = new HashSet<>();
        String[] words = s.split(" ");
        if (pattern.length() != words.length)
            return false;
        for (int i = 0; i < pattern.length(); i++) {
            Character letter = pattern.charAt(i);
            if (map.containsKey(letter) && !map.get(letter).equals(words[i]) || !map.containsKey(letter) && seen.contains(words[i]))
                return false;
            seen.add(words[i]);
            map.put(letter, words[i]);
        }
        return true;
    }
}
