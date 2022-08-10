package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String reformat(String s) {
        StringBuilder digits = new StringBuilder();
        StringBuilder letters = new StringBuilder();
        for (char l : s.toCharArray()) {
            if (Character.isDigit(l))
                digits.append(l);
            else
                letters.append(l);
        }
        if (Math.abs(digits.length() - letters.length()) > 1)
            return "";
        StringBuilder res = new StringBuilder();
        if (digits.length() > letters.length()) {
            for (int i = 0; i < letters.length(); i++) {
                res.append(digits.charAt(i));
                res.append(letters.charAt(i));
            }
        } else {
            for (int i = 0; i < digits.length(); i++) {
                res.append(letters.charAt(i));
                res.append(digits.charAt(i));
            }
        }
        if (digits.length() > letters.length())
            res.append(digits.charAt(digits.length() - 1));
        else if (digits.length() < letters.length())
            res.append(letters.charAt(letters.length() - 1));
        return res.toString();
    }
}
