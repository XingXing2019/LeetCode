package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxPower(String s) {
        Character c = s.charAt(0);
        int count = 0, res = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == c)
                count++;
            else {
                res = Math.max(res, count);
                c = s.charAt(i);
                count = 1;
            }
        }
        return Math.max(res, count);
    }
}
