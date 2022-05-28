package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public String removeOuterParentheses(String s) {
        StringBuilder res = new StringBuilder();
        StringBuilder temp = new StringBuilder();
        int count = 0;
        for (int i = 0; i < s.length(); i++) {
            count += s.charAt(i) == '(' ? 1 : -1;
            temp.append(s.charAt(i));
            if (count == 0) {
                res.append(temp.substring(1, temp.length() - 1));
                temp = new StringBuilder();
            }
        }
        return res.toString();
    }
}
