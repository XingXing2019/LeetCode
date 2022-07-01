package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        String expression = "2*3-4*5";
        System.out.println(diffWaysToCompute(expression));
    }

    public static List<Integer> diffWaysToCompute(String expression) {
        return dfs(expression, new HashMap<>());
    }

    public static List<Integer> dfs(String input, Map<String, List<Integer>> map) {
        if (map.containsKey(input))
            return map.get(input);
        List<Integer> nums = new ArrayList<>();
        if (input.matches("\\d+")) {
            nums.add(Integer.parseInt(input));
            return nums;
        }
        for (int i = 0; i < input.length(); i++) {
            if (Character.isDigit(input.charAt(i)))
                continue;
            List<Integer> left = dfs(input.substring(0, i), map);
            List<Integer> right = dfs(input.substring(i + 1), map);
            for (int l : left) {
                for (int r : right) {
                    if (input.charAt(i) == '-')
                        nums.add(l - r);
                    else if (input.charAt(i) == '+')
                        nums.add(l + r);
                    else
                        nums.add(l * r);
                }
            }
        }
        map.put(input, nums);
        return nums;
    }
}
