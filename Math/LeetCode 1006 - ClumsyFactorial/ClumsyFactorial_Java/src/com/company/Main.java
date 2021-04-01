package com.company;

public class Main {

    public static void main(String[] args) {
        int N = 4;
        System.out.println(clumsy(N));
    }

    public static int clumsy(int N) {
        int res = 0, count = 0, temp = 0;
        boolean first = true;
        for (int i = N; i >= 1; i--) {
            if (count % 4 == 0)
                temp += i;
            else if (count % 4 == 1)
                temp *= i;
            else if (count % 4 == 2)
                temp /= i;
            else if (count % 4 == 3) {
                res += (first ? temp : -temp) + i;
                first = false;
                temp = 0;
            }
            count++;
        }
        return first ? res + temp : res - temp;
    }
}
