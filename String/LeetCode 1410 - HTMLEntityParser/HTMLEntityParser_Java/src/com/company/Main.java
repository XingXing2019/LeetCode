package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        String text = "and I quote: &quot;;...&quot;";
        System.out.println(entityParser(text));
    }

    public static String entityParser(String text) {
        StringBuilder res = new StringBuilder();
        int start = -1;
        Map<String, String> map = new HashMap<>();
        map.put("&quot;", "\"");
        map.put("&apos;", "'");
        map.put("&amp;", "&");
        map.put("&gt;", ">");
        map.put("&lt;", "<");
        map.put("&frasl;", "/");
        for (int i = 0; i < text.length(); i++) {
            if (text.charAt(i) == '&') {
                if (start != -1) {
                    String temp = text.substring(start, i);
                    res.append(temp);
                }
                start = i;
            } else if (text.charAt(i) == ';' && start != -1) {
                String temp = text.substring(start, i + 1);
                res.append(map.getOrDefault(temp, temp));
                start = -1;
            } else if (start == -1)
                res.append(text.charAt(i));
        }
        return res.toString();
    }
}
