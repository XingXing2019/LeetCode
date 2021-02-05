package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int canCompleteCircuit(int[] gas, int[] cost) {
        int[] remain = new int[gas.length];
        int tank = 0;
        for (int i = 0; i < remain.length; i++) {
            remain[i] = gas[i] - cost[i];
            tank += remain[i];
        }
        if(tank < 0) return -1;
        int res = 0;
        tank = 0;
        for (int i = 0; i < remain.length; i++) {
            tank += remain[i];
            if(tank < 0){
                res = i + 1;
                tank = 0;
            }
        }
        return res;
    }
}
