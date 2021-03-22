package com.company;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String[] spellchecker(String[] wordlist, String[] queries) {
        HashSet<String> words = new HashSet<>();
        Map<String, String> lowerCases = new HashMap<>();
        Map<String, String> vowelReplaced = new HashMap<>();
        for (String word : wordlist){
            words.add(word);
            String word1 = word.toLowerCase();
            String word2 = removeVowel(word1);
            if(!lowerCases.containsKey(word1))
                lowerCases.put(word1, word);
            if(!vowelReplaced.containsKey(word2))
                vowelReplaced.put(word2, word);
        }
        String[] res = new String[queries.length];
        for (int i = 0; i < queries.length; i++) {
            String word1 = queries[i].toLowerCase();
            String word2 = removeVowel(word1);
            if(words.contains(queries[i]))
                res[i] = queries[i];
            else if(lowerCases.containsKey(word1))
                res[i] = lowerCases.get(word1);
            else if(vowelReplaced.containsKey(word2))
                res[i] = vowelReplaced.get(word2);
            else
                res[i] = "";
        }
        return res;
    }
    public String removeVowel(String s){
        HashSet<Character> vowels = new HashSet<>(){{add('a'); add('e'); add('i'); add('o'); add('u');}};
        char[] letters = s.toCharArray();
        for (int i = 0; i < letters.length; i++) {
            if(vowels.contains(letters[i]))
                letters[i] = '*';
        }
        return new String(letters);
    }
}
