package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[] fairCandySwap(int[] A, int[] B) {
        int sumA = 0, sumB = 0;
        HashSet<Integer> setA = new HashSet(), setB = new HashSet();
        for (int a : A) {
            setA.add(a);
            sumA += a;
        }
        for (int b : B){
            setB.add(b);
            sumB += b;
        }
        int diff = (sumA + sumB) / 2 - sumA;
        for (Integer a : setA){
            if(setB.contains(a + diff))
                return new int[]{a, a + diff};
        }
        return null;
    }
}
