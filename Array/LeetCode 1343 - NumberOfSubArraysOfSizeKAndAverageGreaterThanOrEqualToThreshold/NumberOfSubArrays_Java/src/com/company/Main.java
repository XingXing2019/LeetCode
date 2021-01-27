package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int numOfSubarrays(int[] arr, int k, int threshold) {
        int[] prefix = new int[arr.length];
        for (int i = 0; i < arr.length; i++)
            prefix[i] = i == 0 ? arr[i] : arr[i] + prefix[i - 1];
        int res = 0;
        for (int i = k - 1; i < arr.length; i++) {
            int sum = i - k < 0 ? prefix[i] : prefix[i] - prefix[i - k];
            if(sum >= threshold * k)
                res++;
        }
        return res;
    }
}
