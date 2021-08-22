package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    int res = Integer.MAX_VALUE;
    public int minimizeTheDifference(int[][] mat, int target) {
        HashSet<Integer>[] visited = new HashSet[mat.length];
        for(int i = 0; i < visited.length; i++)
            visited[i] = new HashSet<Integer>();
        dfs(mat, 0, target, 0, visited);
        return res;
    }

    public void dfs(int[][] mat, int row, int target, int sum, HashSet<Integer>[] visited){
        if(row == mat.length){
            res = Math.min(res, Math.abs(target - sum));
            return;
        }
        if(!visited[row].add(sum) || sum - target >= res)
            return;
        for (int num : mat[row])
            dfs(mat, row + 1, target, sum + num, visited);
    }
}
