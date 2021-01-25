package com.company;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        String[] ops = {"5","2","C","D","+"};
        System.out.print(calPoints_Array(ops));
    }

    public static int calPoints(String[] ops) {
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

    public static int calPoints_Array(String[] ops) {
        int[] nums = new int[ops.length];
        int index = 0, sum = 0;
        for (String op : ops){
            if(op.equals("C")){
                sum -= nums[index - 1];
                index--;
            }
            else if(op.equals("+")){
                nums[index] = nums[index - 1] + nums[index - 2];
                sum += nums[index++];
            }
            else if(op.equals("D")){
                nums[index] = 2 * nums[index - 1];
                sum += nums[index++];
            }
            else{
                nums[index] = Integer.parseInt(op);
                sum += nums[index++];
            }
        }
        return sum;
    }
}
