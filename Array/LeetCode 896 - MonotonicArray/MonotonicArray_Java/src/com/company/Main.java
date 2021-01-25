package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean isMonotonic(int[] A) {
        if(A.length == 1) return true;
        return check(A, true) || check(A, false);
    }
    public boolean check(int[] A, boolean increase){
        for (int i = 1; i < A.length; i++) {
            if(A[i] > A[i - 1] && !increase || A[i] < A[i - 1] && increase)
                return false;
        }
        return true;
    }
}
