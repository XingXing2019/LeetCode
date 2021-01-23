package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean isPalindrome(int x) {
        if(x < 0) return false;
        int copy = x, num = 0;
        while(copy != 0){
            num = num * 10 + copy % 10;
            copy /= 10;
        }
        return num == x;
    }
}
