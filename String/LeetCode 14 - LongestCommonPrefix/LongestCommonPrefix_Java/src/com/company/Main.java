package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String longestCommonPrefix(String[] strs) {
        if(strs.length == 0) return "";
        String prefix = strs[0];
        for (int i = 1; i < strs.length; i++) {
            int p1 = 0, p2 = 0;
            while (p1 < prefix.length() && p2 < strs[i].length() && prefix.charAt(p1) == strs[i].charAt(p2)){
                p1++;
                p2++;
            }
            prefix = prefix.substring(0, p1);
        }
        return prefix;
    }
}
