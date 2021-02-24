package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int maximum69Number (int num) {
        int temp = 0;
        while (num != 0){
            temp = temp * 10 + num % 10;
            num /= 10;
        }
        boolean change = false;
        while (temp != 0){
            int digit = temp % 10;
            if(digit == 6 && !change) {
                digit = 9;
                change = true;
            }
            num = num * 10 + digit;
            temp /= 10;
        }
        return num;
    }
}
