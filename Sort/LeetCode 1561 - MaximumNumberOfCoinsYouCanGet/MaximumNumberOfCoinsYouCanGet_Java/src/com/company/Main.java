package com.company;

import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] piles = {9,8,7,6,5,1,2,3,4};
        maxCoins_PriorityQueue(piles);
    }

    public int maxCoins_Sort(int[] piles) {
        Arrays.sort(piles);
        int res = 0;
        for (int i = piles.length - 2; i >= piles.length / 3; i-=2)
            res += piles[i];
        return res;
    }

    public static int maxCoins_PriorityQueue(int[] piles) {
        PriorityQueue<Integer> queue = new PriorityQueue<>((a, b) -> b - a);
        for (int pile : piles)
            queue.offer(pile);
        int res = 0;
        while (queue.size() > piles.length / 3){
            queue.poll();
            res += queue.poll();
        }
        return res;
    }
}
