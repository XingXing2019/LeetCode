package com.company;

public class Main {

    public static void main(String[] args) {
        res = 6;
        int n = 10;
        System.out.println(guessNumber(n));
    }

    static int res;
    private static int guess(int num) {
        if(num == res) return 0;
        return num > res ? -1 : 1;
    }

    public static int guessNumber(int n) {
        int li = 1, hi = n;
        while (li < hi) {
            int mid = li + (hi - li) / 2;
            if(guess(mid) == 0) return mid;
            if(guess(mid) > 0) li = mid + 1;
            else hi = mid;
        }
        return li;
    }
}
