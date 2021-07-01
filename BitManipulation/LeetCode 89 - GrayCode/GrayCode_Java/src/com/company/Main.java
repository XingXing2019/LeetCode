package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	    int n = 4;
	    System.out.println(grayCode(n));
    }

    public static List<Integer> grayCode(int n) {
        List<Integer> res = new ArrayList<>();
        for (int i = 0; i < Math.pow(2, n); i++)
            res.add((i >> 1) ^ i);
        return res;
    }
}
