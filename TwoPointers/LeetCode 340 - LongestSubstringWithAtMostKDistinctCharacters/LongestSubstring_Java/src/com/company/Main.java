package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	    String s = "eceba";
	    int k = 2;
        System.out.println(lengthOfLongestSubstringKDistinct(s, k));
    }

    public static int lengthOfLongestSubstringKDistinct(String s, int k) {
        int li = 0, hi = 0, res = 0;
        Map<Character, Integer> freq = new HashMap<>();
        while (hi < s.length()) {
            freq.put(s.charAt(hi), freq.getOrDefault(s.charAt(hi), 0) + 1);
            while (freq.size() > k) {
                freq.put(s.charAt(li), freq.get(s.charAt(li)) - 1);
                if (freq.get(s.charAt(li)) == 0)
                    freq.remove(s.charAt(li));
                li++;
            }
            res = Math.max(res, hi - li + 1);
            hi++;
        }
        return res;
    }
}
