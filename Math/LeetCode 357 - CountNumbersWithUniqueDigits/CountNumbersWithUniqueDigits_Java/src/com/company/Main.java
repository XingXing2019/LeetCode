package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int countNumbersWithUniqueDigits(int n) {
        var cur = 1;
        int pow = 1, num = 9;
        for (int i = 0; i < n; i++) {
            var next = pow * num + cur;
            cur = next;
            pow *= num;
            if (i == 0) continue;
            num--;
        }
        return cur;
    }
}
