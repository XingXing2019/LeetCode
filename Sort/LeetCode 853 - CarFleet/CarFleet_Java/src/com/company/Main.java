package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int target = 12;
        int[] position = {10, 8, 0, 5, 3}, speed = {2, 4, 1, 1, 3};
        System.out.println(carFleet(target, position, speed));
    }

    public static int carFleet(int target, int[] position, int[] speed) {
        int[][] record = new int[position.length][];
        for (int i = 0; i < position.length; i++)
            record[i] = new int[]{position[i], speed[i]};
        Arrays.sort(record, (a, b) -> a[0] - b[0]);
        double[] timeToTarget = new double[record.length];
        for (int i = 0; i < record.length; i++)
            timeToTarget[i] = ((double) target - record[i][0]) / record[i][1];
        int hi = timeToTarget.length - 1, li = timeToTarget.length - 1, res = 0;
        while (li >= 0) {
            while (li >= 0 && timeToTarget[li] <= timeToTarget[hi])
                li--;
            res++;
            hi = li;
        }
        return res;
    }
}
