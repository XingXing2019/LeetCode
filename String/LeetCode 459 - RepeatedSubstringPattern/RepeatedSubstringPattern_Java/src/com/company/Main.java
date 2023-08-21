package com.company;

public class Main {

    public static void main(String[] args) {
	    String s = "aba";
        System.out.println(repeatedSubstringPattern(s));
    }

    public static boolean repeatedSubstringPattern(String s) {
        for (int i = 1; i < s.length(); i++) {
            if (s.length() % i != 0) continue;
            if(s.substring(0, i).repeat(s.length() / i).equals(s))
                return true;
        }
        return false;
    }
}
