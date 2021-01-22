package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isOneEditDistance(String s, String t) {
        if (s.equals(t)) return false;
        char[] cS = s.toCharArray(), cT = t.toCharArray();
        return check(cS, cT) || check(cT, cS);
    }

    public boolean check(char[] s, char[] t) {
        if (s.length > t.length || t.length - s.length > 1) return false;
        var chance = 1;
        int p1 = 0, p2 = 0;
        while (p1 < s.length && p2 < t.length) {
            if (s[p1] != t[p2]) {
                chance--;
                if (chance < 0) return false;
                if (s.length == t.length) p1++;
            } else
                p1++;
            p2++;
        }
        return true;
    }
}
