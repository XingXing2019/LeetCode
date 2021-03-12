package com.company;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        String s = "leetcode";
        List<String> wordDict = new LinkedList<>() {{
            add("leet");
            add("code");
        }};
        System.out.println(wordBreak_dp(s, wordDict));
    }

    static boolean canForm;
    public static boolean wordBreak_backTracking(String s, List<String> wordDict) {
        dfs(s, wordDict);
        return canForm;
    }

    public static void dfs(String remain, List<String> wordDict) {
        if (canForm || remain.length() == 0) {
            canForm = true;
            return;
        }
        for (String word : wordDict) {
            if (word.length() <= remain.length() && remain.substring(0, word.length()).equals(word))
                dfs(remain.substring(word.length()), wordDict);
        }
    }

    public static boolean wordBreak_dp(String s, List<String> wordDict) {
        boolean[] check = new boolean[s.length() + 1];
        check[check.length - 1] = true;
        HashSet<String> set = new HashSet<>();
        for (String word : wordDict)
            set.add(word);
        for (int i = check.length - 2; i >= 0; i--) {
            StringBuilder temp = new StringBuilder();
            for (int j = i; j < s.length(); j++) {
                temp.append(s.charAt(j));
                if(set.contains(temp.toString()) && check[j + 1]){
                    check[i] = true;
                    break;
                }
            }
        }
        return check[0];
    }
}
