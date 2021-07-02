package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int maxIceCream(int[] costs, int coins) {
        int res = 0, index = 0;
        Arrays.sort(costs);
        while (index < costs.length && coins >= costs[index]){
            coins -= costs[index++];
            res++;
        }
        return res;
    }
}
