package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<Integer> findAnagrams(String s, String p) {
        List<Integer> res = new ArrayList<>();
        if (p.length() > s.length()) return res;
        int[] letters = new int[26];
        for (int i = 0; i < p.length(); i++) {
            letters[p.charAt(i) - 'a']++;
            letters[s.charAt(i) - 'a']--;
        }
        for (int i = p.length(); i < s.length(); i++) {
            if (Arrays.stream(letters).allMatch(x -> x == 0))
                res.add(i - p.length());
            letters[s.charAt(i) - 'a']--;
            letters[s.charAt(i - p.length()) - 'a']++;
        }
        if (Arrays.stream(letters).allMatch(x -> x == 0))
            res.add(s.length() - p.length());
        return res;
    }
}
