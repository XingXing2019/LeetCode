package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<String> generateParenthesis(int n) {
        List<String> res = new ArrayList<>();
        dfs("", res, 0, 0, n);
        return res;
    }

    private void dfs(String parenthesis, List<String> res, int open, int close, int n) {
        if (parenthesis.length() == n * 2) {
            res.add(parenthesis);
            return;
        }
        if (open < n)
            dfs(parenthesis + '(', res, open + 1, close, n);
        if (close < open)
            dfs(parenthesis + ')', res, open, close + 1, n);
    }
}
