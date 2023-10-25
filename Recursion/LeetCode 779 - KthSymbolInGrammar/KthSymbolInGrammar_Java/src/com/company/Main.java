package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int kthGrammar(int n, int k) {
        if (n == 1 && k == 1)
            return 0;
        if (k % 2 == 0)
            return kthGrammar(n - 1, k / 2) == 1 ? 0 : 1;
        return kthGrammar(n - 1, (k + 1) / 2) == 0 ? 0 : 1;
    }
}
