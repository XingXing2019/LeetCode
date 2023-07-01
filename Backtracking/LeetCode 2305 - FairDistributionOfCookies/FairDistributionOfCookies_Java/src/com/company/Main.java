package com.company;

public class Main {

    public static void main(String[] args) {
	    int[] cookies = {8,15, 10};
	    int k = 2;
        System.out.println(distributeCookies(cookies, k));
    }

    static int res;
    public static int distributeCookies(int[] cookies, int k) {
        res = Integer.MAX_VALUE;
        dfs(cookies, 0, 0, new int[k]);
        return res;
    }

    public static void dfs(int[] cookies, int index, int max, int[] children) {
        if (index == cookies.length) {
            res = Math.min(res, max);
            return;
        }
        for (int i = 0; i < children.length; i++) {
            children[i] += cookies[index];
            dfs(cookies, index + 1, Math.max(max, children[i]), children);
            children[i] -= cookies[index];
        }
    }
}
