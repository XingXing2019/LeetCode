package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minDominoRotations(int[] tops, int[] bottoms) {
        var res = Integer.MAX_VALUE;
        for (int i = 1; i <= 6; i++) {
            var opt1 = countSwap(tops, bottoms, i);
            var opt2 = countSwap(bottoms, tops, i);
            if (opt1 == -1 && opt2 == -1) continue;
            if (opt1 != -1) res = Math.min(res, opt1);
            if (opt2 != -1) res = Math.min(res, opt2);
        }
        return res == Integer.MAX_VALUE ? -1 : res;
    }

    public int countSwap(int[] arr1, int[] arr2, int target) {
        var res = 0;
        for (int i = 0; i < arr1.length; i++) {
            if (arr1[i] == target) continue;
            else if (arr2[i] == target) res++;
            else return -1;
        }
        return res;
    }
}
