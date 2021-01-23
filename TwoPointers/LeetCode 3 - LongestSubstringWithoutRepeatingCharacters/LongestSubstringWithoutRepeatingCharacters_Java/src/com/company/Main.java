package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int lengthOfLongestSubstring(String s) {
        var record = new int[128];
        int li  = 0, hi = 0, res = 0;
        var letters = s.toCharArray();
        while (hi < letters.length){
            record[letters[hi]]++;
            while(record[letters[hi]] > 1 && li < hi)
                record[letters[li++]]--;
            res = Math.max(res, hi - li + 1);
            hi++;
        }
        return res;
    }
}
