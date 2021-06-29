package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String convertToTitle(int columnNumber) {
        String res = "";
        while (columnNumber > 26) {
            int temp = columnNumber % 26 - 1;
            if (temp < 0) temp += 26;
            res = (char) (temp + 'A') + res;
            if(columnNumber % 26 == 0) columnNumber--;
            columnNumber /= 26;
        }
        return (char) (columnNumber - 1 + 'A') + res;
    }
}
