package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class MovingAverage {
    double _sum;
    int _size;
    Queue<Integer> _queue;
    public MovingAverage(int size) {
        _size = size;
        _sum = 0;
        _queue = new ArrayDeque<>();
    }

    public double next(int val) {
        _queue.offer(val);
        _sum += val;
        if(_queue.size() > _size)
            _sum -= _queue.poll();
        return _sum / _queue.size();
    }
}