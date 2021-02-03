package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int leastInterval(char[] tasks, int n) {
        Map<Character, Integer> map = new HashMap<>();
        int maxFreq = 0;
        for (char t : tasks){
            map.put(t, map.getOrDefault(t, 0) + 1);
            maxFreq = Math.max(maxFreq, map.get(t));
        }
        int maxFreqCount = 0;
        for (var kv : map.entrySet()){
            if(kv.getValue() == maxFreq)
                maxFreqCount++;
        }
        return Math.max(tasks.length, (n + 1) * (maxFreq - 1) + maxFreqCount);
    }
}
