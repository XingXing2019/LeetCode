package com.company;

import java.util.Arrays;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[][] course = {
                new int[]{5, 5},
                new int[]{4, 6},
                new int[]{2, 6},
        };
        System.out.println(scheduleCourse(course));
    }

    public static int scheduleCourse(int[][] courses) {
        Arrays.sort(courses, (a, b) -> a[1] - b[1]);
        PriorityQueue<Integer> heap = new PriorityQueue<>((a, b) -> b - a);
        int days = 0;
        for (int[] course : courses) {
            if (days + course[0] <= course[1]) {
                heap.offer(course[0]);
                days += course[0];
            } else if (!heap.isEmpty() && heap.peek() > course[0] && days - heap.peek() + course[0] <= course[1]) {
                days -= heap.poll() - course[0];
                heap.offer(course[0]);
            }
        }
        return heap.size();
    }
}
