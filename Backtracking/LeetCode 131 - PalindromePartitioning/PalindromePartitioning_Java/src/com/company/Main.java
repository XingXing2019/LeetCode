package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public List<List<String>> partition(String s) {
        List<List<String>> res = new ArrayList<>();
        dfs(s, new ArrayList<>(), res);
        return res;
    }
    
    public void dfs(String s, List<String> path, List<List<String>> res){
        if(s.isEmpty()){
            res.add(new ArrayList<>(path));
            return;
        }
        for (int i = 1; i <= s.length(); i++) {
            if(check(s.substring(0, i))){
                path.add(s.substring(0, i));
                dfs(s.substring(i), path, res);
                path.remove(path.size() - 1);
            }
        }
    }
    public boolean check(String s){
        int li = 0, hi = s.length() - 1;
        while (li < hi){
            if(s.charAt(li++) != s.charAt(hi--))
                return false;
        }
        return true;
    }
}
