package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int numRescueBoats(int[] people, int limit) {
        Arrays.sort(people);
        int li = 0, hi = people.length - 1, res = 0;
        while (li < hi) {
            if (people[li] + people[hi] <= limit)
                li++;
            res++;
            hi--;
        }
        return li == hi ? res + 1 : res;
    }
}
