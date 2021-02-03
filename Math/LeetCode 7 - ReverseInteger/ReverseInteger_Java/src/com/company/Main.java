package com.company;

public class Main {

    public static void main(String[] args) {
        System.out.print(-123 / 10);
    }
    public int reverse(int x) {
        int res = 0;
        while (x != 0){
            if(res > Integer.MAX_VALUE / 10 || res < Integer.MIN_VALUE / 10) return 0;
            res = res * 10 + x % 10;
            x /= 10;
        }
        return res;
    }
}
