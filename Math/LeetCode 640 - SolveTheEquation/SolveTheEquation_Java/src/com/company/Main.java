package com.company;

public class Main {

    public static void main(String[] args) {
        String equation = "-x=-1";
        System.out.println(solveEquation(equation));
    }

    public static String solveEquation(String equation) {
        String[] equations = equation.split("\\=");
        int[] left = readEquation(equations[0]);
        int[] right = readEquation(equations[1]);
        int x = left[0] - right[0], num = right[1] - left[1];
        if (x == 0) return num == 0 ? "Infinite solutions" : "No solution";
        return "x=" + num / x;
    }

    public static int[] readEquation(String equation) {
        StringBuilder str = new StringBuilder();
        for (char l : equation.toCharArray()) {
            if (l == '-')
                str.append('+');
            str.append(l);
        }
        String[] parts = str.toString().split("\\+");
        int[] res = new int[2];
        for (String part : parts) {
            if (part.equals("")) continue;
            if (part.charAt(part.length() - 1) == 'x') {
                if (part.length() == 1)
                    res[0] += 1;
                else {
                    String temp = part.substring(0, part.length() - 1);
                    res[0] += temp.equals("-") ? -1 : Integer.parseInt(temp);
                }
            } else
                res[1] += Integer.parseInt(part);
        }
        return res;
    }
}
