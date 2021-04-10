package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class Logger {
    Map<String, Integer> map;
    public Logger() {
        map = new HashMap<>();
    }

    public boolean shouldPrintMessage(int timestamp, String message) {
        if (!map.containsKey(message)) {
            map.put(message, timestamp + 10);
            return true;
        } else {
            if(map.get(message) > timestamp)
                return false;
            else{
                map.put(message, timestamp + 10);
                return true;
            }
        }
    }
}
