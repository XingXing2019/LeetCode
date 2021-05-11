package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[] decode(int[] encoded) {
        int all = 0, exceptLast = 0;
        for (int i = 1; i <= encoded.length + 1; i++)
            all ^= i;
        for (int i = 0; i < encoded.length; i += 2)
            exceptLast ^= encoded[i];
        int[] res = new int[encoded.length + 1];
        res[res.length - 1] = all ^ exceptLast;
        for (int i = res.length - 2; i >= 0; i--)
            res[i] = encoded[i] ^ res[i + 1];
        return res;
    }
}
