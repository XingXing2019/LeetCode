package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] distributeCandies(int candies, int num_people) {
        int count = 0;
        int[] res = new int[num_people];
        while (candies > 0){
            res[count % num_people] += Math.min(candies, ++count);
            candies -= count;
        }
        return res;
    }
}
