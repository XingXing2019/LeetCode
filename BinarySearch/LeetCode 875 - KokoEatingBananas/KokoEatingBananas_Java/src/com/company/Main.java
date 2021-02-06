package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int minEatingSpeed(int[] piles, int H) {
        int li = 1, hi = 0;
        for (int p : piles) hi = Math.max(hi , p);
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            int time = 0;
            for (int p : piles)
                time += p % mid == 0 ? p / mid : p / mid + 1;
            if(time > H) li = mid + 1;
            else hi = mid - 1;
        }
        return li;
    }
}
