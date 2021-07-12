package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isIsomorphic(String s, String t) {
        Map<Character, Character> mapS = new HashMap<>();
        Map<Character, Character> mapT = new HashMap<>();
        for (int i = 0; i < s.length(); i++) {
            if (mapT.containsKey(t.charAt(i)) && mapT.get(t.charAt(i)) != s.charAt(i))
                return false;
            else if (mapS.containsKey(s.charAt(i)) && mapS.get(s.charAt(i)) != t.charAt(i))
                return false;
            mapS.put(s.charAt(i), t.charAt(i));
            mapT.put(t.charAt(i), s.charAt(i));
        }
        return true;
    }
}
