package com.company;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int calPoints(String[] ops) {
        ArrayList<Integer> stack = new ArrayList<>();
        for (String op : ops){
            if(op.equals("C"))
                stack.remove(stack.size() - 1);
            else if(op.equals("+"))
                stack.add(stack.get(stack.size() - 1) + stack.get(stack.size() - 2));
            else if(op.equals("D"))
                stack.add(stack.get(stack.size() - 1) * 2);
            else
                stack.add(Integer.parseInt(op));
        }
        return stack.stream().mapToInt(x -> x).sum();
    }
}
