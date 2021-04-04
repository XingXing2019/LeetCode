package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class MyCircularQueue {
    List<Integer> queue;
    int size;
    int index;

    public MyCircularQueue(int k) {
        queue = new ArrayList<>();
        size = k;
        index = 0;
    }

    public boolean enQueue(int value) {
        if (isFull()) return false;
        queue.add(value);
        return true;
    }

    public boolean deQueue() {
        if (isEmpty()) return false;
        index++;
        return true;
    }

    public int Front() {
        return isEmpty() ? -1 : queue.get(index);
    }

    public int Rear() {
        return isEmpty() ? -1 : queue.get(queue.size() - 1);
    }

    public boolean isEmpty() {
        return queue.size() - index == 0;
    }

    public boolean isFull() {
        return queue.size() - index >= size;
    }
}

