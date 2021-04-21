package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<List<Integer>> triangle = new ArrayList<>();
        triangle.add(new ArrayList<>(){{add(2);}});
        triangle.add(new ArrayList<>(){{add(3);add(4);}});
        triangle.add(new ArrayList<>(){{add(6);add(5);add(7);}});
        triangle.add(new ArrayList<>(){{add(4);add(1);add(8);add(3);}});
        System.out.println(minimumTotal(triangle));
    }

    public static int minimumTotal(List<List<Integer>> triangle) {
        if (triangle.size() == 1) return triangle.get(0).get(0);
        List<Integer> pre = new ArrayList<>() {{
            add(triangle.get(0).get(0));
        }};
        int res = Integer.MAX_VALUE;
        for (int i = 1; i < triangle.size(); i++) {
            List<Integer> cur = new ArrayList<>();
            for (int j = 0; j < triangle.get(i).size(); j++) {
                if (j == 0)
                    cur.add(triangle.get(i).get(j) + pre.get(j));
                else if (j == triangle.get(i).size() - 1)
                    cur.add(triangle.get(i).get(j) + pre.get(j - 1));
                else
                    cur.add(triangle.get(i).get(j) + Math.min(pre.get(j), pre.get(j - 1)));
                if (i == triangle.size() - 1)
                    res = Math.min(res, cur.get(j));
            }
            pre = cur;
        }
        return res;
    }
}
