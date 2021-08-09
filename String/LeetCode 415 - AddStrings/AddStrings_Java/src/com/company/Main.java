package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String addStrings(String num1, String num2) {
        String res = "";
        int p1 = num1.length() - 1, p2 = num2.length() - 1;
        int car = 0, cur = 0;
        while (p1 >= 0 && p2 >= 0) {
            cur = (num1.charAt(p1) - '0' + num2.charAt(p2) - '0' + car) % 10;
            car = (num1.charAt(p1--) - '0' + num2.charAt(p2--) - '0' + car) / 10;
            res = cur + res;
        }
        while (p1 >= 0) {
            cur = (num1.charAt(p1) - '0' + car) % 10;
            car = (num1.charAt(p1--) - '0' + car) / 10;
            res = cur + res;
        }
        while (p2 >= 0) {
            cur = (num2.charAt(p2) - '0' + car) % 10;
            car = (num2.charAt(p2--) - '0' + car) / 10;
            res = cur + res;
        }
        if(car != 0) res = car + res;
        return res;
    }
}
