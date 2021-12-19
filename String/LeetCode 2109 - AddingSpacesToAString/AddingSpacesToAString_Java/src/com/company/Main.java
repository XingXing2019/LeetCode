package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String addSpaces(String s, int[] spaces) {
        StringBuilder res = new StringBuilder();
        int index = 0;
        for (int i = 0; i < spaces.length; i++) {
            int len = i == 0 ? spaces[i] : spaces[i] - spaces[i - 1];
            res.append(s.substring(index, index + len) + " ");
            index += len;
        }
        return res + s.substring(index);
    }
}
