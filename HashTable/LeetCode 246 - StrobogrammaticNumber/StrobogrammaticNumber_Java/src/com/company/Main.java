package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        String num = "69";
        isStrobogrammatic(num);
    }

    public static boolean isStrobogrammatic(String num) {
        Map<Character, Character> map = new HashMap<>() {{
            put('0', '0');
            put('1', '1');
            put('6', '9');
            put('8', '8');
            put('9', '6');
        }};
        int li = 0, hi = num.length() - 1;
        while (li <= hi){
            if(!map.containsKey(num.charAt(li)) || map.get(num.charAt(li++)) != num.charAt(hi--))
                return false;
        }
        return true;
    }
}
