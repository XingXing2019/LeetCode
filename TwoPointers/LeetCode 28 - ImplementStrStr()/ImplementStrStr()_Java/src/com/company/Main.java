package com.company;

public class Main {

    public static void main(String[] args) {
        String haystack = "hello", needle = "ll";
        System.out.println(strStr(haystack, needle));
    }

    public static int strStr(String haystack, String needle) {
        if (haystack.length() < needle.length()) return -1;
        int pow = 1, time = 256, prime = 101, hHash = 0, nHash = 0;
        for (int i = 0; i < needle.length() - 1; i++)
            pow = pow * time % prime;
        for (int i = 0; i < needle.length(); i++) {
            nHash = (nHash * time + needle.charAt(i)) % prime;
            hHash = (hHash * time + haystack.charAt(i)) % prime;
        }
        for (int i = 0; i <= haystack.length() - needle.length(); i++) {
            if (nHash == hHash) {
                int len = 0;
                while (len < needle.length()) {
                    if (needle.charAt(len) != haystack.charAt(len + i))
                        break;
                    len++;
                }
                if (len == needle.length()) return i;
            } else {
                if (i + needle.length() >= haystack.length()) break;
                hHash = ((hHash - haystack.charAt(i) * pow) * time + haystack.charAt(i + needle.length())) % prime;
                if (hHash < 0) hHash += prime;
            }
        }
        return -1;
    }
}
