package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean isHappy(int n) {
        HashSet<Integer> set = new HashSet<>();
        while (set.add(n)){
            int temp = 0;
            while (n != 0){
                temp += (n % 10) * (n % 10);
                n /= 10;
            }
            if(temp == 1) return true;
            n = temp;
        }
        return false;
    }
}
