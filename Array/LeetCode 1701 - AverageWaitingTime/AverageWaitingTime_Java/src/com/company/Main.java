package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public double averageWaitingTime(int[][] customers) {
        double waitTime = 0, cur = customers[0][0];
        for (int[] customer : customers){
            cur = Math.max(cur, customer[0]);
            waitTime += cur - customer[0] + customer[1];
            cur += customer[1];
        }
        return waitTime / customers.length;
    }
}
