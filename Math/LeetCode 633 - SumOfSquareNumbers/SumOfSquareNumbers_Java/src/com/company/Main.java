package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean judgeSquareSum(int c) {
        int li = 0, hi = (int)Math.sqrt(c);
        while (li <= hi){
            if(li * li + hi * hi == c)
                return true;
            if(li * li + hi * hi > c)
                hi--;
            else
                li++;
        }
        return false;
    }
}
