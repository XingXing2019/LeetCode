package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String removeDuplicates(String S) {
        StringBuilder res = new StringBuilder();
        for (Character l : S.toCharArray()){
            if(res.length() == 0 || l != res.charAt(res.length() - 1))
                res.append(l);
            else
                res.deleteCharAt(res.length() - 1);
        }
        return res.toString();
    }
}
