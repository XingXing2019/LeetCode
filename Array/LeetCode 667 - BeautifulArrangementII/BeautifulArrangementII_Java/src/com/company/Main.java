package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] ConstructArray(int n, int k) {
        int temp = k + 1;
        int[] res = new int[n];
        res[0] = 1;
        for (int i = 1; i < n && k != 0; i++) {
            res[i] += i % 2 != 0 ? res[i - 1] + k : res[i - 1] -k;
            k--;
        }
        for (int i = res.length - 1; i >= temp; i--) {
            res[i] = n;
            n--;
        }
        return res;
    }
}
