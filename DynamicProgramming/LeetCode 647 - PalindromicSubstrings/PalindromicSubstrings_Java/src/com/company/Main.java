package com.company;

public class Main {

    public static void main(String[] args) {
        String s = "aba";
        System.out.println(countSubstrings(s));
    }

    public static int countSubstrings(String s) {
        int count = s.length();
        for (int i = 0; i < s.length(); i++) {
            int li = i - 1, hi = i + 1;
            while (li >= 0 && hi < s.length()) {
                if (s.charAt(li--) == s.charAt(hi++)) count++;
                else break;
            }
        }
        for (int i = 0; i < s.length() - 1; i++) {
            if (s.charAt(i) == s.charAt(i + 1)) {
                count++;
                int li = i - 1, hi = i + 2;
                while (li >= 0 && hi < s.length()) {
                    if (s.charAt(li--) == s.charAt(hi++)) count++;
                    else break;
                }
            }
        }
        return count;
    }
}
