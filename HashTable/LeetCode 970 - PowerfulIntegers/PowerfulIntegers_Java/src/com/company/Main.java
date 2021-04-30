package com.company;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<Integer> powerfulIntegers(int x, int y, int bound) {
        HashSet<Integer> res = new HashSet<>();
        int numX = 1;
        while (numX < bound) {
            int numY = 1;
            while (numY < bound){
                if (numX + numY <= bound)
                    res.add(numX + numY);
                if(y == 1) break;
                numY *= y;
            }
            if (x == 1) break;
            numX *= x;
        }
        return new ArrayList<>(res);
    }
}
