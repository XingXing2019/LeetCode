package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int fib(int n) {
        if(n < 2) return n;
        int num1 = 0, num2 = 1;
        for (int i = 1; i < n; i++) {
            int temp = num1 + num2;
            num1 = num2;
            num2 = temp;
        }
        return num2;
    }
}
