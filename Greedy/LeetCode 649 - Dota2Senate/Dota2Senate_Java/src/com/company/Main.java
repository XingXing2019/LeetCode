package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public String predictPartyVictory(String senate) {
        Queue<Integer> radiant = new ArrayDeque<>();
        Queue<Integer> dire = new ArrayDeque<>();
        for (int i = 0; i < senate.length(); i++) {
            if (senate.charAt(i) == 'R')
                radiant.offer(i);
            else
                dire.offer(i);
        }
        while (!radiant.isEmpty() && !dire.isEmpty()){
            if (radiant.peek() < dire.peek()){
                dire.poll();
                radiant.offer(radiant.poll() + senate.length());
            }
            else{
                radiant.poll();
                dire.offer(dire.poll() + senate.length());
            }
        }
        return radiant.isEmpty() ? "Dire" : "Radiant";
    }
}
