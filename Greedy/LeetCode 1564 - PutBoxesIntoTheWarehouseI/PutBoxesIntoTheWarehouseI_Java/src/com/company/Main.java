package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxBoxesInWarehouse(int[] boxes, int[] warehouse) {
        int[] maxHeight = new int[warehouse.length];
        int min = Integer.MAX_VALUE;
        for (int i = 0; i < warehouse.length; i++) {
            min = Math.min(min, warehouse[i]);
            maxHeight[i] = min;
        }
        Arrays.sort(boxes);
        int p1 = 0, p2 = maxHeight.length - 1;
        while (p1 < boxes.length && p2 >= 0) {
            if (boxes[p1] <= maxHeight[p2])
                p1++;
            p2--;
        }
        return p1;
    }
}
