package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean hasAlternatingBits(int n) {
        int bit = n & 1;
        while (n != 0) {
            if ((n & 1) != bit)
                return false;
            bit ^= 1;
            n >>= 1;
        }
        return true;
    }
}
