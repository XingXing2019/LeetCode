package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int target = 10, startFuel = 10;
        int[][] stations = new int[][]{
                new int[]{10, 60},
                new int[]{20, 30},
                new int[]{30, 30},
                new int[]{60, 40},
        };
        System.out.println(minRefuelStops(target, startFuel, stations));
    }

    public static int minRefuelStops(int target, int startFuel, int[][] stations) {
        PriorityQueue<int[]> maxHeap = new PriorityQueue<>((a, b) -> b[1] - a[1]);
        int res = 0, index = 0;
        while (startFuel < target) {
            while (index < stations.length && stations[index][0] <= startFuel)
                maxHeap.add(stations[index++]);
            if (maxHeap.isEmpty()) break;
            startFuel += maxHeap.poll()[1];
            res++;
        }
        return startFuel < target ? -1 : res;
    }
}
