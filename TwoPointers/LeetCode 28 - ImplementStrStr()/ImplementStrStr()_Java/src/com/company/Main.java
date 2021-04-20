package com.company;

public class Main {

    public static void main(String[] args) {
        String haystack = "hello", needle = "ll";
        System.out.println(strStr(haystack, needle));
    }

    public static int strStr(String haystack, String needle) {
        int prime = 101, power = 1;
        for (int i = 0; i < needle.length() - 1; i++)
            power = power * 265 % prime;
        int needleHash = 0, hayHash = 0;
        for (int i = 0; i < needle.length(); i++) {
            needleHash = (needleHash * 256 + needle.charAt(i)) % prime;
            hayHash = (hayHash * 256 + haystack.charAt(i)) % prime;
        }
        for (int i = 0; i <= haystack.length() - needle.length(); i++) {
            if (hayHash == needleHash) {
                boolean same = true;
                for (int j = 0; j < needle.length(); j++) {
                    if (haystack.charAt(i + j) != needle.charAt(j)) {
                        same = false;
                        break;
                    }
                }
                if (same) return i;
            } else {
                hayHash = ((hayHash - haystack.charAt(i) * power) * 256 + haystack.charAt(i + needle.length())) % prime;
                if (hayHash < 0) hayHash += prime;
            }
        }
        return -1;
    }
}
