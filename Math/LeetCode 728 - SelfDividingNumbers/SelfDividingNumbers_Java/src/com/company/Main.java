package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<Integer> selfDividingNumbers(int left, int right) {
        List<Integer> res = new ArrayList<>();
        for (int i = left; i <= right; i++) {
            if (!isValid(i)) continue;
            res.add(i);
        }
        return res;
    }

    public boolean isValid(int num) {
        int copy = num;
        while (copy != 0) {
            int mod = copy % 10;
            if (mod == 0 || num % mod != 0) return false;
            copy /= 10;
        }
        return true;
    }
}
