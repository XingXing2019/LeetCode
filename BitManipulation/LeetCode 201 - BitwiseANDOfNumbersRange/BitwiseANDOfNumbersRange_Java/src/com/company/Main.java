package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int rangeBitwiseAnd(int left, int right) {
        int count = 0;
        while (right != left) {
            right >>= 1;
            left >>= 1;
            count++;
        }
        for (int i = 0; i < count; i++)
            left <<= 1;
        return left;
    }
}
