package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int hammingDistance(int x, int y) {
        int res = 0;
        while (x != 0 || y != 0){
            res += (x & 1) ^ (y & 1);
            x >>= 1;
            y >>= 1;
        }
        return res;
    }
}
