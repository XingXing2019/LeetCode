package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<Integer> partitionLabels(String s) {
        int[] lastIndex = new int[26];
        Arrays.fill(lastIndex, -1);
        for (int i = s.length() - 1; i >= 0; i--) {
            int letter = s.charAt(i) - 'a';
            lastIndex[letter] = Math.max(lastIndex[letter], i);
        }
        int li = -1, hi = 0;
        List<Integer> res = new ArrayList<>();
        HashSet<Character> set = new HashSet<>();
        while (hi < s.length()) {
            set.add(s.charAt(hi));
            if (hi == lastIndex[s.charAt(hi) - 'a'])
                set.remove(s.charAt(hi));
            if (set.size() == 0) {
                res.add(hi - li);
                li = hi;
            }
            hi++;
        }
        return res;
    }
}
