package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maximumUnits(int[][] boxTypes, int truckSize) {
        Arrays.sort(boxTypes, (a, b) -> b[1] - a[1]);
        int res = 0, index = 0;
        while (index < boxTypes.length && truckSize - boxTypes[index][0] > 0) {
            res += boxTypes[index][0] * boxTypes[index][1];
            truckSize -= boxTypes[index++][0];
        }
        if (index < boxTypes.length)
            res += Math.min(truckSize, boxTypes[index][0]) * boxTypes[index][1];
        return res;
    }
}
