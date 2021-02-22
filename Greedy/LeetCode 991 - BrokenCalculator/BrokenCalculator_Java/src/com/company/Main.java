package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int brokenCalc(int X, int Y) {
        int res = 0;
        while (Y > X){
            if(Y % 2 == 0) Y /= 2;
            else Y += 1;
            res++;
        }
        return res + X - Y;
    }
}
