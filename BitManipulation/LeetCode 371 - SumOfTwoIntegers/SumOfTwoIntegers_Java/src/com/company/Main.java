package com.company;

public class Main {

    public static void main(String[] args) {
	    int a = 1, b = 3;
	    System.out.println(getSum(a, b));
    }
    public static int getSum(int a, int b) {
        if(b == 0) return a;
        return getSum(a ^ b, (a & b) << 1);
    }
}
