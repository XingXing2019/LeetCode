package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public void reverseString(char[] s) {
        int li = 0, hi = s.length - 1;
        while (li < hi) {
            char temp = s[li];
            s[li++] = s[hi];
            s[hi--] = temp;
        }
    }
}
