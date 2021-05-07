package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int xorOperation(int n, int start) {
        int res = start;
        for (int i = 1; i < n; i++)
            res ^= start + 2 * i;
        return res;
    }
}
