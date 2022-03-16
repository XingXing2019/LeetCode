package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[][] order = {{10, 5, 0}, {15, 2, 1}, {25, 1, 1}, {30, 4, 0}};
        System.out.println(getNumberOfBacklogOrders(order));
    }

    public static int getNumberOfBacklogOrders(int[][] orders) {
        PriorityQueue<int[]> buy = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        PriorityQueue<int[]> sell = new PriorityQueue<>((a, b) -> a[0] - b[0]);
        for (int i = 0; i < orders.length; i++) {
            var order = orders[i];
            if (order[2] == 0) {
                while (!sell.isEmpty() && sell.peek()[0] <= order[0] && sell.peek()[1] <= order[1])
                    order[1] -= sell.poll()[1];
                if (!sell.isEmpty() && sell.peek()[0] <= order[0])
                    sell.peek()[1] -= order[1];
                else if (order[1] > 0)
                    buy.offer(new int[]{order[0], order[1]});
            } else {
                while (!buy.isEmpty() && buy.peek()[0] >= order[0] && buy.peek()[1] <= order[1])
                    order[1] -= buy.poll()[1];
                if (!buy.isEmpty() && buy.peek()[0] >= order[0])
                    buy.peek()[1] -= order[1];
                else if (order[1] > 0)
                    sell.offer(new int[]{order[0], order[1]});
            }
        }
        long res = 0, mod = 1_000_000_000 + 7;
        while (!buy.isEmpty())
            res = (res + buy.poll()[1]) % mod;
        while (!sell.isEmpty())
            res = (res + sell.poll()[1]) % mod;
        return (int) res;
    }
}
