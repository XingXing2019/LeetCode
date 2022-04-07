package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean rotateString(String s, String goal) {
        return s.length() == goal.length() && (s + s).contains(goal);
    }
}
