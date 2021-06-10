package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {

    }
}

class MyCalendar {
    List<int[]> bookings;
    public MyCalendar() {
        bookings = new ArrayList<>();
    }

    public boolean book(int start, int end) {
        for (int[] booking : bookings) {
            if (booking[0] <= start && start < booking[1])
                return false;
            if (booking[0] < end && end <= booking[1])
                return false;
            if (booking[0] <= start && end <= booking[1])
                return false;
            if (start <= booking[0] && booking[1] <= end)
                return false;
        }
        bookings.add(new int[]{start, end});
        return true;
    }
}
