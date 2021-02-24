package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] closestDivisors(int num) {
        int[] candidate1 = getDivisors(num + 1);
        int[] candidate2 = getDivisors(num + 2);
        return Math.abs(candidate1[0] - candidate1[1]) < Math.abs(candidate2[0] - candidate2[1]) ? candidate1 : candidate2;
    }
    public int[] getDivisors(int num){
        int sqrt = (int) Math.sqrt(num) + 1;
        for (int i = sqrt; i > 0; i--) {
            if(num % i == 0)
                return new int[]{i, num / i};
        }
        return null;
    }
}
