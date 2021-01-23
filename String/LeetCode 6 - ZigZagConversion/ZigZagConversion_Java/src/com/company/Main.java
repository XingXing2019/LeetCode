package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	    String s = "PAYPALISHIRING";
	    int numRows = 3;
	    System.out.print(convert(s, numRows));
    }
    public static String convert(String s, int numRows) {
        if(numRows == 1) return s;
        ArrayList<String> record[] = new ArrayList[numRows];
        boolean movingDown = true;
        int r = 0;
        char[] letters = s.toCharArray();
        for (char l: letters) {
            if(record[r] == null) record[r] = new ArrayList<String>();
            record[r].add(Character.toString(l));
            r += movingDown ? 1 : -1;
            if(r < 0 || r >= record.length){
                r += movingDown ? -2 : 2;
                movingDown = !movingDown;
            }
        }
        String res = "";
        for (var row : record){
            if(row != null)
                res += String.join("", row);
        }
        return res;
    }
}
