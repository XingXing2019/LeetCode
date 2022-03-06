package com.company;

public class Main {

    public static void main(String[] args) {
	    int n = 3;
        System.out.println(countOrders(n));
    }

    public static int countOrders(int n) {
        long res = 1, mod = 1_000_000_000 + 7;
        for (int i = 2; i <= n; i++)
            res = (res * (2L * i * i - i)) % mod;
        return (int) (res % mod);
    }
}
