package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        String path = "/a/./b/../.././.././.././../c/";
        System.out.println(simplifyPath(path));
    }
    public static String simplifyPath(String path) {
        String[] parts = path.split("/");
        Stack<String> stack = new Stack<>();
        for (String p : parts){
            if(p.isEmpty() || p.equals(".")) continue;
            if(p.equals("..") && !stack.isEmpty())
                stack.pop();
            else if(!p.equals("..")) stack.push(p);
        }
        String res = "";
        while (!stack.isEmpty())
            res = "/" + stack.pop() + res;
        return res.isEmpty() ? "/" : res;
    }
}
