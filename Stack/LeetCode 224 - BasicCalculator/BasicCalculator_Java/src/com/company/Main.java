package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        String s = "(1+(4+5+2)-3)+(6+8)";
        System.out.println(calculate(s));
    }

    public static int calculate(String s) {
        StringBuilder num = new StringBuilder();
        Stack<Character> operators = new Stack<>();
        Stack<Integer> nums = new Stack<>();
        for (Character l : s.toCharArray()){
            if(l == ' ') continue;
            if(Character.isDigit(l))
                num.append(l);
            else {
                if(num.length() != 0) nums.push(Integer.parseInt(num.toString()));
                num = new StringBuilder();
                if(l == ')'){
                    int temp = 0;
                    while (!operators.isEmpty() && operators.peek() != '(')
                        temp += operators.pop() == '-' ? -nums.pop() : nums.pop();
                    temp += nums.pop();
                    operators.pop();
                    nums.push(temp);
                }
                else
                    operators.push(l);
            }
        }
        if(num.length() != 0) nums.push(Integer.parseInt(num.toString()));
        int res = 0;
        while (!nums.isEmpty())
            res += operators.isEmpty() || operators.pop() == '+' ? nums.pop() : -nums.pop();
        return res;
    }
}
