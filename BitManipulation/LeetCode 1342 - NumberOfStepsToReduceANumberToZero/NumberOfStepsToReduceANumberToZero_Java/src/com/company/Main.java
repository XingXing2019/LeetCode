package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int numberOfSteps (int num) {
        int res = 0;
        while (num != 0){
            if(num % 2 == 0) num /= 2;
            else num -= 1;
            res++;
        }
        return res;
    }
}
