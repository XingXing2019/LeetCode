package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        String s = "25525511135";
        System.out.println(restoreIpAddresses(s));
    }

    public static List<String> restoreIpAddresses(String s) {
        ArrayList<String> res = new ArrayList<>();
        backTracking(s, res, new ArrayList<>());
        return res;
    }

    public static void backTracking(String remain, List<String> res, List<String> parts){
        if(parts.size() > 4) return;
        if(parts.size() == 4){
            if(remain.length() == 0)
                res.add(String.join(".", parts));
            return;
        }
        for (int i = 1; i <= 3 && i <= remain.length(); i++) {
            String part = remain.substring(0, i);
            if(part.length() > 1 && part.charAt(0) == '0' || Integer.parseInt(part) > 255) continue;
            parts.add(part);
            backTracking(remain.substring(i), res, parts);
            parts.remove(parts.size() - 1);
        }
    }
}
