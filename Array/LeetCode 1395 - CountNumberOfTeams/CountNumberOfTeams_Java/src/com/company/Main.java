package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int numTeams(int[] rating) {
        int[] smaller = new int[rating.length];
        int[] bigger = new int[rating.length];
        int res = 0;
        for (int i = 0; i < rating.length; i++) {
            for (int j = i + 1; j < rating.length; j++) {
                if (rating[i] > rating[j])
                    smaller[i]++;
                else if (rating[i] < rating[j])
                    bigger[i]++;
            }
        }
        for (int i = 0; i < rating.length; i++) {
            for (int j = i + 1; j < rating.length; j++) {
                if (rating[i] > rating[j])
                    res += smaller[j];
                else if (rating[i] < rating[j])
                    res += bigger[j];
            }
        }
        return res;
    }
}
