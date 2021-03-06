package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	    String[] words = {"ctxdic","c"};
	    minimumLengthEncoding(words);
    }
    public static int minimumLengthEncoding(String[] words) {
        HashSet<String> set = new HashSet<>();
        for (String word : words) set.add(word);
        for (String word : words){
            for (int i = 0; i < word.length(); i++) {
                String temp = word.substring(word.length() - i - 1);
                if(!temp.equals(word) && set.contains(temp))
                    set.remove(temp);
            }
        }
        int res = 0;
        for (String word : set)
            res += word.length() + 1;
        return res;
    }
}
