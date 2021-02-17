package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	    String S = "a1";
	    letterCasePermutation(S);
    }
    public static List<String> letterCasePermutation(String S) {
        List<String> res = new ArrayList<>();
        dfs(0, S.toCharArray(), res);
        return res;
    }
    public static void dfs(int index, char[] S, List<String> res){
        if(index == S.length){
            res.add(new String(S));
            return;
        }
        if(Character.isLetter(S[index])){
            S[index] = Character.isUpperCase(S[index]) ? Character.toLowerCase(S[index]) : Character.toUpperCase(S[index]);
            dfs(index + 1, S, res);
            S[index] = Character.isUpperCase(S[index]) ? Character.toLowerCase(S[index]) : Character.toUpperCase(S[index]);
            dfs(index + 1, S, res);
        }
        else
            dfs(index + 1, S, res);
    }
}
