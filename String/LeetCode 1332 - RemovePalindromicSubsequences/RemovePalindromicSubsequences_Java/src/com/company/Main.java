package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int removePalindromeSub(String s) {
        if (s.equals("")) return 0;
        return checkPalindromeSub(s) ? 1 :2;
    }

    public boolean checkPalindromeSub(String s) {
        int li = 0, hi = s.length() - 1;
        while (li < hi) {
            if (s.charAt(li++) != s.charAt(hi--))
                return false;
        }
        return true;
    }
}
