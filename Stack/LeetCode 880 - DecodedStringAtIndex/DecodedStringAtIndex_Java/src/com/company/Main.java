package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        String s = "a2345678999999999999999";
        int k = 1;
        System.out.println(decodeAtIndex(s, k));
    }

    public static String decodeAtIndex(String s, int k) {
        long size = 0;
        for (Character l : s.toCharArray()) {
            if (Character.isDigit(l))
                size *= l - '0';
            else
                size++;
        }
        for (int i = s.length() - 1; i >= 0; i--) {
            Character l = s.charAt(i);
            k %= size;
            if (k == 0 && Character.isLetter(l))
                return Character.toString(l);
            if (Character.isDigit(l))
                size /= l - '0';
            else
                size--;
        }
        return "";
    }
}
