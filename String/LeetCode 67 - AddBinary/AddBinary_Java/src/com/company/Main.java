package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String addBinary(String a, String b) {
        StringBuilder res = new StringBuilder();
        int cur = 0, car = 0, p1 = a.length() - 1, p2 = b.length() - 1;
        while (p1 >= 0 && p2 >= 0) {
            cur = (a.charAt(p1) - '0' + b.charAt(p2) - '0' + car) % 2;
            car = (a.charAt(p1--) - '0' + b.charAt(p2--) - '0' + car) / 2;
            res.append(cur);
        }
        while (p1 >= 0) {
            cur = (a.charAt(p1) - '0' + car) % 2;
            car = (a.charAt(p1--) - '0' + car) / 2;
            res.append(cur);
        }
        while (p2 >= 0) {
            cur = (b.charAt(p2) - '0' + car) % 2;
            car = (b.charAt(p2--) - '0' + car) / 2;
            res.append(cur);
        }
        if (car == 1) res.append(car);
        return res.reverse().toString();
    }
}
