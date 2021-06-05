package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String parseTernary(String expression) {
        if (expression.length() == 1) return expression;
        int count = 0;
        for (int i = 0; i < expression.length(); i++) {
            if (expression.charAt(i) == '?')
                count++;
            else if (expression.charAt(i) == ':')
                count--;
            if (count == 0 && expression.charAt(i) == ':')
                return expression.charAt(0) == 'T'
                        ? parseTernary(expression.substring(2, i))
                        : parseTernary(expression.substring(i + 1));
        }
        return "";
    }
}
