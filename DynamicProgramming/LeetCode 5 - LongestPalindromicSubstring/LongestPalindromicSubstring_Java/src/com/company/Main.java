package com.company;

public class Main {

    public static void main(String[] args) {
        var s = "babad";
        System.out.print(longestPalindrome(s));
    }
    public static String longestPalindrome(String s) {
        var res = "";
        for (int i = 0; i < s.length(); i++) {
            var palindrome1 = getPalindrome(s, i, i);
            var palindrome2 = getPalindrome(s, i, i + 1);
            if(palindrome1.length() > res.length())
                res = palindrome1;
            if(palindrome2.length() > res.length())
                res = palindrome2;
        }
        return res;
    }
    public static String getPalindrome(String s, int c1, int c2){
        var letters = s.toCharArray();
        if(c2 >= letters.length) return "";
        int k = 0;
        while(c1 - k >= 0 && c2 + k < letters.length && letters[c1 - k] == letters[c2 + k])
            k++;
        return s.substring(c1 - k + 1, c2 + k);
    }
}
