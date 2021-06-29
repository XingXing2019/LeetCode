package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isArmstrong(int n) {
        int k = Integer.toString(n).length();
        int num = 0, copy = n;
        while (copy != 0) {
            double temp = copy % 10;
            copy /= 10;
            num += Math.pow(temp, k);
        }
        return num == n;
    }
}
