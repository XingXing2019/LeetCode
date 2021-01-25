package com.company;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public List<Integer> addToArrayForm(int[] A, int K) {
        int index = A.length - 1, car = 0, cur = 0;
        List<Integer> res = new ArrayList<>();
        while (index >= 0 && K != 0){
            cur = (A[index] + K % 10 + car) % 10;
            car = (A[index] + K % 10 + car) / 10;
            res.add(cur);
            index--;
            K /= 10;
        }
        while (index >= 0){
            cur = (A[index] + car) % 10;
            car = (A[index] + car) / 10;
            res.add(cur);
            index--;
        }
        while (K != 0){
            cur = (K % 10 + car) % 10;
            car = (K % 10 + car) / 10;
            res.add(cur);
            K /= 10;
        }
        if(car == 1) res.add(car);
        Collections.reverse(res);
        return res;
    }
}
