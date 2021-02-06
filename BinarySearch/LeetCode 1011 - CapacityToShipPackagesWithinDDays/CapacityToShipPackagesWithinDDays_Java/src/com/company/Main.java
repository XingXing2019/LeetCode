package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	    int[] weight = {1, 2, 3, 1, 1};
	    int D = 4;
	    shipWithinDays(weight, D);
    }
    public static int shipWithinDays(int[] weights, int D) {
        int li = 0, hi = 0;
        for(int w : weights){
            li = Math.max(li, w);
            hi += w;
        }
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            int count = 0, ship = 0;
            for(int w : weights){
                if(ship + w > mid){
                    ship = 0;
                    count++;
                }
                ship += w;
            }
            count++;
            if(count > D) li = mid + 1;
            else hi = mid - 1;
        }
        return li;
    }
}
