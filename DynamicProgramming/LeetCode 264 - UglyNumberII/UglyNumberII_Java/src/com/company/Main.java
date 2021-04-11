package com.company;

import java.util.HashSet;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int n = 10;
        System.out.println(nthUglyNumber_dp(n));
    }

    public static int nthUglyNumber_heap(int n) {
        PriorityQueue<Integer> heap = new PriorityQueue<>();
        HashSet<Integer> set = new HashSet<>();
        int[] times = {2, 3, 5};
        heap.offer(1);
        for (int i = 1; i < n; i++) {
            int min = heap.poll();
            for (int j = 0; j < times.length; j++) {
                if (Integer.MAX_VALUE / times[j] > min && set.add(min * times[j]))
                    heap.offer(min * times[j]);
            }
        }
        return heap.poll();
    }

    public static int nthUglyNumber_dp(int n) {
        int[] dp = new int[n];
        dp[0] = 1;
        int two = 0, three = 0, five = 0;
        for (int i = 1; i < n; i++) {
            dp[i] = Math.min(dp[two] * 2, Math.min(dp[three] * 3, dp[five] * 5));
            if (dp[two] * 2 == dp[i]) two++;
            if (dp[three] * 3 == dp[i]) three++;
            if (dp[five] * 5 == dp[i]) five++;
        }
        return dp[n - 1];
    }
}
