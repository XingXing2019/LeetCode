package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    private boolean isBadVersion(int version) {
        return true;
    }

    public int firstBadVersion(int n) {
        int li = 1, hi = n;
        while (li < hi) {
            int mid = li + (hi - li) / 2;
            if (isBadVersion(mid)) hi = mid;
            else li = mid + 1;
        }
        return li;
    }
}
