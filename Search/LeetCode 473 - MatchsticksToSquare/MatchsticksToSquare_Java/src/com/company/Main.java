package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] matches = {1, 1, 2, 2, 2};
        System.out.println(makesquare(matches));
    }

    static boolean made;
    public static boolean makesquare(int[] matchsticks) {
        int sum = 0;
        for (int matchStick : matchsticks)
            sum += matchStick;
        if (sum % 4 != 0) return false;
        int target = sum / 4;
        Arrays.sort(matchsticks);
        int[] bucket = new int[4];
        dfs(matchsticks.length - 1, matchsticks, target, bucket);
        return made;
    }

    private static void dfs(int index, int[] matchSticks, int target, int[] bucket) {
        if (index == -1 || made) {
            if (bucket[0] == target && bucket[1] == target && bucket[2] == target && bucket[3] == target)
                made = true;
            return;
        }
        for (int i = 0; i < 4; i++) {
            if (bucket[i] > target) continue;
            bucket[i] += matchSticks[index];
            dfs(index - 1, matchSticks, target, bucket);
            bucket[i] -= matchSticks[index];
        }
    }
}
