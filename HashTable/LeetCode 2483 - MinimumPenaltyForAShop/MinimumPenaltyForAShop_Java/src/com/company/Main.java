package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int bestClosingTime(String customers) {
        int[] beforeNo = new int[customers.length() + 1];
        int[] afterYes = new int[customers.length() + 1];
        int yes = 0, no = 0, min = Integer.MAX_VALUE, res = 0;
        for (int i = 0; i < customers.length(); i++) {
            beforeNo[i] = no;
            no += customers.charAt(i) == 'N' ? 1 : 0;
        }
        beforeNo[beforeNo.length - 1] = no;
        for (int i = customers.length() - 1; i >= 0; i--) {
            yes += customers.charAt(i) == 'Y' ? 1 : 0;
            afterYes[i] = yes;
        }
        for (int i = 0; i < beforeNo.length; i++) {
            if (beforeNo[i] + afterYes[i] >= min) continue;
            min = beforeNo[i] + afterYes[i];
            res = i;
        }
        return res;
    }
}
