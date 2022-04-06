package com.company;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        int[] arr = {1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        int target = 8;
        System.out.println(threeSumMulti(arr, target));
    }

    public static int threeSumMulti(int[] arr, int target) {
        long res = 0, mod = 1_000_000_000 + 7;
        Arrays.sort(arr);
        Map<Integer, Integer> map = new HashMap<>();
        for (int num : arr)
            map.put(num, map.getOrDefault(num, 0) + 1);
        for (int i = 0; i < arr.length; i++) {
            int li = i + 1, hi = arr.length - 1;
            while (li < hi) {
                int sum = arr[i] + arr[li] + arr[hi];
                if (sum > target) hi--;
                else if (sum < target) li++;
                else {
                    int small = arr[li], countSmall = 0;
                    if (small == arr[hi]) {
                        res += (hi - li + 1) * (hi - li) / 2;
                        break;
                    }
                    while (li < hi && arr[li] == small) {
                        li++;
                        countSmall++;
                    }
                    res += countSmall * map.get(arr[hi]);
                }
            }
        }
        return (int) (res % mod);
    }
}
