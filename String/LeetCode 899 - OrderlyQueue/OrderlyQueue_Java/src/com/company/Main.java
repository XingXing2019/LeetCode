package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public String orderlyQueue(String s, int k) {
        if (k > 1)
            return orderString(s);
        else {
            HashSet<String> set = new HashSet<String>();
            String res = s;
            while (set.add(s)) {
                s = s.substring(1) + s.charAt(0);
                if (s.compareTo(res) < 0)
                    res = s;
            }
            return res;
        }
    }

    private String orderString(String s) {
        int[] letters = new int[26];
        StringBuilder res = new StringBuilder();
        for (char l : s.toCharArray())
            letters[l - 'a']++;
        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < letters[i]; j++)
                res.append((char) (i + 'a'));
        }
        return res.toString();
    }
}
