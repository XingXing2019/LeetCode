package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] arr = {1, 0, 0, 2};
        duplicateZeros(arr);
    }

    public static void duplicateZeros(int[] arr) {
        int len = arr.length, p1 = 0, p2 = arr.length - 1;
        boolean single = false;
        while (p1 < arr.length && len > 0) {
            len -= arr[p1++] == 0 ? 2 : 1;
            if (len < 0) single = true;
        }
        while (p2 >= 0) {
            if (arr[p1 - 1] == 0) {
                arr[p2--] = 0;
                if (!single) arr[p2--] = 0;
                single = false;
            } else
                arr[p2--] = arr[p1 - 1];
            p1--;
        }
    }
}
