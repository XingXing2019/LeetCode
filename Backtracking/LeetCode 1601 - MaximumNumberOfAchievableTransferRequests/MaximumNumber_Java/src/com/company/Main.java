package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    int res;
    public int maximumRequests(int n, int[][] requests) {
        res = 0;
        int[] net = new int[n];
        dfs(requests, 0, 0, net);
        return res;
    }

    public void dfs(int[][] requests, int start, int count, int[] net) {
        if (Arrays.stream(net).allMatch(x -> x == 0))
            res = Math.max(res, count);
        for (int i = start; i < requests.length; i++) {
            net[requests[i][0]]--;
            net[requests[i][1]]++;
            dfs(requests, i + 1, count + 1, net);
            net[requests[i][0]]++;
            net[requests[i][1]]--;
        }
    }
}
