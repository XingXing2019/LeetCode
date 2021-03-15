package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class Codec {

    int index;
    Map<String, String> map = new HashMap<>();
    public String encode(String longUrl) {
        map.put(Integer.toString(index++), longUrl);
        return Integer.toString(index);
    }

    public String decode(String shortUrl) {
        return map.get(Integer.toString(index - 1));
    }
}
