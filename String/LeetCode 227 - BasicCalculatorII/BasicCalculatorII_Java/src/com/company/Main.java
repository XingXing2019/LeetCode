package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
	    String s = "3+2*2";
	    System.out.println(calculate(s));
    }

    public static int calculate(String s) {
        s += '@';
        char[] letters = s.toCharArray();
        Stack<Integer> nums = new Stack<>();
        Stack<Character> operators = new Stack<>();
        int num = 0, res = 0;
        for (int i = 0; i < letters.length; i++) {
            if(letters[i] == ' ') continue;
            if(Character.isDigit(letters[i]))
                num = num * 10 + (letters[i] - '0');
            else {
                if(operators.isEmpty() || operators.peek() == '+')
                    nums.push(num);
                else if(!operators.isEmpty() && operators.peek() == '-')
                    nums.push(-num);
                else if(!operators.isEmpty() && operators.peek() == '*')
                    nums.push(nums.pop() * num);
                else if(!operators.isEmpty() && operators.peek() == '/')
                    nums.push(nums.pop() / num);
                if(!operators.isEmpty()) operators.pop();
                operators.push(letters[i]);
                num = 0;
            }
        }
        while (!nums.isEmpty()) res += nums.pop();
        return res;
    }
}
