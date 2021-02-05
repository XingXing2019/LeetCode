package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int hIndex(int[] citations) {
        int li = 0, hi = citations.length - 1;
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            if(citations[mid] == citations.length - mid) return citations[mid];
            if(citations[mid] > citations.length - mid) hi = mid - 1;
            else li = mid + 1;
        }
        return citations.length - li;
    }
}
