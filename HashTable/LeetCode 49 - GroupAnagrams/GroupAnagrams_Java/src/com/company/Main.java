package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public List<List<String>> groupAnagrams(String[] strs) {
        HashMap<String, List<String>> map = new HashMap<>();
        for (String str : strs){
            String code = encode(str.toCharArray());
            if(!map.containsKey(code))
                map.put(code, new ArrayList<>());
            map.get(code).add(str);
        }
        List<List<String>> res = new ArrayList<>();
        for(var kv : map.entrySet())
            res.add(kv.getValue());
        return res;
    }
    public String encode(char[] str){
        int[] letters = new int[26];
        for (Character l : str)
            letters[l - 'a']++;
        StringBuilder code = new StringBuilder();
        for (int count : letters)
            code.append(count + "-");
        return code.toString();
    }
}
