package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int hIndex(int[] citations) {
        Arrays.sort(citations);
        int res = 0;
        for (int i = 0; i < citations.length; i++) {
            if(citations[i] >= citations.length - i)
                res = Math.max(res, citations.length - i);
        }
        return res;
    }
}
