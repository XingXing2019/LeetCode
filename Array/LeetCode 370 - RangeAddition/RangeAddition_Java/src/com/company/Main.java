package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] getModifiedArray(int length, int[][] updates) {
        int[] res = new int[length];
        for (int[] update : updates){
            res[update[0]] += update[2];
            if(update[1] + 1 < res.length)
                res[update[1] + 1] -= update[2];
        }
        int num = 0;
        for (int i = 0; i < length; i++) {
            num += res[i];
            res[i] = num;
        }
        return res;
    }
}
