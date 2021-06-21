package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<List<Integer>> generate(int numRows) {
        List<Integer> cur = new ArrayList<>();
        cur.add(1);
        List<List<Integer>> res = new ArrayList<>();
        for (int i = 0; i < numRows; i++) {
            res.add(cur);
            List<Integer> next = new ArrayList<>();
            for (int j = 0; j < cur.size() + 1; j++) {
                if (j == 0 || j == cur.size())
                    next.add(1);
                else
                    next.add(cur.get(j - 1) + cur.get(j));
            }
            cur = next;
        }
        return res;
    }
}
