package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean canChange(String start, String target) {
        String trimStart = start.replace("_", "");
        String trimTarget = target.replace("_", "");
        if (!trimStart.equals(trimTarget))
            return false;
        List<Integer> startL = new ArrayList<>();
        List<Integer> startR = new ArrayList<>();
        List<Integer> targetL = new ArrayList<>();
        List<Integer> targetR = new ArrayList<>();
        for (int i = 0; i < start.length(); i++) {
            if (start.charAt(i) == 'L')
                startL.add(i);
            else if (start.charAt(i) == 'R')
                startR.add(i);
            if (target.charAt(i) == 'L')
                targetL.add(i);
            else if (target.charAt(i) == 'R')
                targetR.add(i);
        }
        for (int i = 0; i < startL.size(); i++) {
            if (startL.get(i) < targetL.get(i))
                return false;
        }
        for (int i = 0; i < startR.size(); i++) {
            if (startR.get(i) > targetR.get(i))
                return false;
        }
        return true;
    }
}
