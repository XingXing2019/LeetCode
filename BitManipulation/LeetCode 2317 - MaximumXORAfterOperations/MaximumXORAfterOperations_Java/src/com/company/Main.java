package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maximumXOR(int[] nums) {
        int res = 0;
        for (int i = 0; i < 32; i++) {
            int count = 0;
            for (int num : nums) {
                if ((num >> i & 1) == 1)
                    count++;
            }
            if (count == 0) continue;
            res += (1 << i);
        }
        return res;
    }
}
