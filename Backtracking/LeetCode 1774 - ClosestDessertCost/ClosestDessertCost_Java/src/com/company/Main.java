package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    int res;

    public int closestCost(int[] baseCosts, int[] toppingCosts, int target) {
        res = Integer.MAX_VALUE;
        for (int baseCost : baseCosts)
            dfs(toppingCosts, baseCost, target, 0);
        return res;
    }

    public void dfs(int[] toppingCosts, int cost, int target, int index) {
        if (Math.abs(target - res) > Math.abs(target - cost))
            res = cost;
        if (index == toppingCosts.length || cost > target)
            return;
        for (int i = 0; i <= 2; i++)
            dfs(toppingCosts, cost + toppingCosts[index] * i, target, index + 1);
    }
}
