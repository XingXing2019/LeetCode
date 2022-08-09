package com.company;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int numFactoredBinaryTrees(int[] arr) {
        long res = 0, mod = 1_000_000_000 + 7;
        Map<Double, Long> dp = new HashMap<>();
        Arrays.sort(arr);
        for (int num : arr)
            dp.put((double)num, 1L);
        for (int i = 0; i < arr.length; i++) {
            for (int j = i - 1; j >= 0; j--) {
                double num = (double)arr[i] / arr[j];
                if (!dp.containsKey(num)) continue;
                dp.put((double) arr[i], dp.get((double) arr[i]) + dp.get((double) arr[j]) * dp.get(num));
            }
            res += dp.get((double) arr[i]);
        }
        return (int) (res % mod);
    }
}
