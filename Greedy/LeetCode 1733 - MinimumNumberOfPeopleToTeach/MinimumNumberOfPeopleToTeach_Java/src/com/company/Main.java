package com.company;

import java.util.ArrayList;
import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int minimumTeachings(int n, int[][] languages, int[][] friendships) {
        boolean[][] matrix = new boolean[languages.length][];
        for (int i = 0; i < languages.length; i++) {
            if(matrix[i] == null) matrix[i] = new boolean[n];
            for (int l : languages[i])
                matrix[i][l - 1] = true;
        }
        ArrayList<int[]> friends = new ArrayList<>();
        for (int[] friend : friendships){
            boolean knowSameLanguage = false;
            for (int i = 0; i < n; i++) {
                if(!matrix[friend[0] - 1][i] || !matrix[friend[1] - 1][i]) continue;
                knowSameLanguage = true;
                break;
            }
            if(!knowSameLanguage) friends.add(friend);
        }
        int res = Integer.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            HashSet<Integer> set = new HashSet<>();
            for(int[] friend : friends){
                if(!matrix[friend[0] - 1][i]) set.add(friend[0]);
                if(!matrix[friend[1] - 1][i]) set.add(friend[1]);
            }
            res = Math.min(res, set.size());
        }
        return res;
    }
}
