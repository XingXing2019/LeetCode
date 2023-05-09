package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public double myPow(double x, int n) {
        return n >= 0 ? pow(x, n) : 1 / pow(x, n);
    }

    public double pow(double x, int n) {
        if (n == 0) return 1;
        var pow = pow(x, n / 2);
        return n % 2 == 0 ? pow * pow : pow * pow * x;
    }
}
