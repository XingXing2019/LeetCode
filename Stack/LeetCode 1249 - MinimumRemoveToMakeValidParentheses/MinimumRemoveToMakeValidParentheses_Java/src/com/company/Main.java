package com.company;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String minRemoveToMakeValid(String s) {
        HashSet<Integer> illegal = new HashSet<>();
        int left = 0, right = 0;
        for (int i = 0; i < s.length(); i++) {
            if(s.charAt(i) == '(') left++;
            else if (s.charAt(i) == ')'){
                if(left > 0) left--;
                else illegal.add(i);
            }
        }
        for (int i = s.length() - 1; i >= 0; i--) {
            if(s.charAt(i) == ')') right++;
            else if(s.charAt(i) == '('){
                if(right > 0) right--;
                else illegal.add(i);
            }
        }
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < s.length(); i++) {
            if(!illegal.contains(i))
                res.append(s.charAt(i));
        }
        return res.toString();
    }
}
