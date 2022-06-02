package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String alphabetBoardPath(String target) {
        char start = 'a';
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < target.length(); i++) {
            char l = target.charAt(i);
            res.append(getPath(start, l));
            start = l;
        }
        return res.toString();
    }

    public static String getPath(Character startL, Character endL) {
        int startX = (startL - 'a') / 5, startY = (startL - 'a') % 5;
        int endX = (endL - 'a') / 5, endY = (endL - 'a') % 5;
        int x = endX - startX;
        int y = endY - startY;
        if (startL == 'z')
            return "U".repeat(-x) + "R".repeat(y) + '!';
        if (endL == 'z')
            return "L".repeat(-y) + "D".repeat(x) + '!';
        String res = x > 0 ? "D".repeat(x) : "U".repeat(-x);
        res += y > 0 ? "R".repeat(y) : "L".repeat(-y);
        return res + '!';
    }
}
