package com.company;

public class Main {

    public static void main(String[] args) {
        String dominoes = ".L.R.";
        System.out.println(pushDominoes(dominoes));
    }

    public static String pushDominoes(String dominoes) {
        int left = -1, right = dominoes.length();
        var res = dominoes.toCharArray();
        for (int i = 0; i < res.length; i++) {
            if (res[i] == '.') continue;
            if (res[i] == 'L') {
                int li = right, hi = i;
                if (right < i) {
                    while (li < hi) {
                        res[li++] = 'R';
                        res[hi--] = 'L';
                    }
                    right = dominoes.length();
                } else {
                    while (hi > left)
                        res[hi--] = 'L';
                }
                left = i;
            } else {
                while (right < i)
                    res[right++] = 'R';
                right = i;
            }
        }
        while (right < dominoes.length())
            res[right++] = 'R';
        return new String(res);
    }
}
