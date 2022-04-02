package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int findMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        PriorityQueue<int[]> maxProfit = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        PriorityQueue<int[]> projects = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        for (int i = 0; i < profits.length; i++)
            projects.offer(new int[]{profits[i], capital[i]});
        int res = w;
        for (int i = 0; i < Math.min(k, profits.length); i++) {
            while (!projects.isEmpty() && projects.peek()[1] <= w)
                maxProfit.offer(projects.poll());
            if (!maxProfit.isEmpty()) {
                int[] project = maxProfit.poll();
                w += project[0];
                res += project[0];
            }
        }
        return res;
    }
}
