package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<String> letterCombinations(String digits) {
        if(digits.isEmpty()) return new ArrayList<>();
        String[] board = {"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        List<String> res = new ArrayList<>();
        dfs(digits, 0, new StringBuilder(), board, res);
        return res;
    }

    public void dfs(String digits, int index, StringBuilder word, String[] board, List<String> res) {
        if (index == digits.length()) {
            res.add(word.toString());
            return;
        }
        for (int i = 0; i < board[digits.charAt(index) - '0'].length(); i++) {
            word.append(board[digits.charAt(index) - '0'].charAt(i));
            dfs(digits, index + 1, word, board, res);
            word.deleteCharAt(word.length() - 1);
        }
    }
}
