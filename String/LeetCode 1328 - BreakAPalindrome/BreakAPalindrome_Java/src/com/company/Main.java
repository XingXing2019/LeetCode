package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public String breakPalindrome(String palindrome) {
        if(palindrome.length() == 1) return "";
        StringBuilder str = new StringBuilder(palindrome);
        for (int i = 0; i < palindrome.length() / 2; i++) {
            if(str.charAt(i) != 'a'){
                str.setCharAt(i, 'a');
                return str.toString();
            }
        }
        str.setCharAt(palindrome.length() - 1, 'b');
        return str.toString();
    }
}
