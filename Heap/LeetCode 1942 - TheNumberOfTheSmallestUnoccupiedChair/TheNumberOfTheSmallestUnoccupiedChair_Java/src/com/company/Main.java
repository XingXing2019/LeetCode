package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int smallestChair(int[][] times, int targetFriend) {
        PriorityQueue<int[]> occupied = new PriorityQueue<int[]>((a, b) -> a[1] - b[1]);
        PriorityQueue<Integer> available = new PriorityQueue<>();
        int seat = 0;
        int[][] friends = new int[times.length][];
        for (int i = 0; i < friends.length; i++)
            friends[i] = new int[]{times[i][0], times[i][1], i};
        Arrays.sort(friends, (a, b) -> a[0] - b[0]);
        for (var friend : friends) {
            while (!occupied.isEmpty() && occupied.peek()[1] <= friend[0]) {
                int[] unoccupied = occupied.poll();
                available.offer(unoccupied[0]);
            }
            if (available.isEmpty()) {
                occupied.offer(new int[]{seat, friend[1]});
                if (friend[2] == targetFriend) return seat;
                seat++;
            } else {
                int newSeat = available.poll();
                occupied.offer(new int[]{newSeat, friend[1]});
                if (friend[2] == targetFriend) return newSeat;
            }
        }
        return -1;
    }
}