package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class CombinationIterator {
    int index;
    List<String> strs;
    public CombinationIterator(String characters, int combinationLength) {
        strs = new ArrayList<>();
        dfs(characters, 0, combinationLength, "", strs);
    }

    private void dfs(String characters, int start, int combinationLength, String combo, List<String> strs) {
        if (combo.length() == combinationLength)
            strs.add(combo);
        for (int i = start; i < characters.length(); i++)
            dfs(characters, i + 1, combinationLength, combo + characters.charAt(i), strs);
    }

    public String next() {
        return strs.get(index++);
    }

    public boolean hasNext() {
        return index != strs.size();
    }
}