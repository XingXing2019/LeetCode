package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String[] findRelativeRanks(int[] score) {
        String[] res = new String[score.length];
        int maxScore = Arrays.stream(score).max().getAsInt();
        int[] record = new int[maxScore + 1];
        for (int i = 0; i < score.length; i++)
            record[score[i]] = i + 1;
        String[] medals = {"Gold Medal","Silver Medal","Bronze Medal"};
        int index = 0;
        for (int i = record.length - 1; i >= 0; i--) {
            if(record[i] == 0) continue;
            res[record[i] - 1] = index < 3 ? medals[index++] : Integer.toString(++index);
        }
        return res;
    }
}
