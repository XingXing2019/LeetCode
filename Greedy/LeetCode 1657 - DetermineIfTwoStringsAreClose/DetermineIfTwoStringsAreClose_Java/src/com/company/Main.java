package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean closeStrings(String word1, String word2) {
        if (word1.length() != word2.length()) return false;
        char[] c1 = word1.toCharArray(), c2 = word2.toCharArray();
        var record1 = new int[26];
        var record2 = new int[26];
        for (int i = 0; i < c1.length; i++){
            record1[c1[i] - 'a']++;
            record2[c2[i] - 'a']++;
        }
        var map = new HashMap<Integer, Integer>();
        for (int i = 0; i < 26; i++) {
            if(record1[i] == 0 && record2[i] != 0 || record1[i] != 0 && record2[i] == 0)
                return false;
            if(!map.containsKey(record1[i]))
                map.put(record1[i], 0);
            map.put(record1[i], map.get(record1[i]) + 1);
            if(!map.containsKey(record2[i]))
                map.put(record2[i], 0);
            map.put(record2[i], map.get(record2[i]) - 1);
        }
        for (var kv: map.entrySet()) {
            if(kv.getValue() != 0) return false;
        }
        return true;
    }
}
