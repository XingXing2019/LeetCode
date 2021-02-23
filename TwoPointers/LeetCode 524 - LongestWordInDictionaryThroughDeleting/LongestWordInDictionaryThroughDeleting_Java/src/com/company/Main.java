package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        String s = "abpcplea";
        List<String> d = new ArrayList<>() {
            {
                add("a");
                add("b");
                add("c");
            }
        };
        findLongestWord(s, d);
    }

    public static String findLongestWord(String s, List<String> d) {
        String res = "";
        for (String t : d) {
            if (Check(s, t) && (t.length() > res.length() || t.length() == res.length() && res.compareTo(t) > 0))
                res = t;
        }
        return res;
    }

    public static boolean Check(String s, String t) {
        int p1 = 0, p2 = 0;
        while (p1 < s.length() && p2 < t.length()) {
            if (s.charAt(p1) == t.charAt(p2))
                p2++;
            p1++;
        }
        return p2 == t.length();
    }
}
