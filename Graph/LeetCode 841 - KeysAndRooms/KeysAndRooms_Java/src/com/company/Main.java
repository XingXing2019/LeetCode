package com.company;

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean canVisitAllRooms(List<List<Integer>> rooms) {
        HashSet<Integer> visited = new HashSet<>(){{add(0);}};
        ArrayDeque<Integer> queue = new ArrayDeque<>();
        queue.offer(0);
        while (!queue.isEmpty()){
            int cur = queue.poll();
            for (int next : rooms.get(cur)){
                if(visited.add(next))
                    queue.offer(next);
            }
        }
        return visited.size() == rooms.size();
    }
}
