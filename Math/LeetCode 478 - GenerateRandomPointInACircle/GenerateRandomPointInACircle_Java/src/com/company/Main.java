package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class Solution {
    double _x;
    double _y;
    double _radius;
    public Solution(double radius, double x_center, double y_center) {
        _x = x_center;
        _y = y_center;
        _radius = radius;
    }

    public double[] randPoint() {
        double x = 0, y = 0;
        do {
            x = (Math.random() > 0.5 ? 1 : -1) * Math.random() * _radius;
            y = (Math.random() > 0.5 ? 1 : -1) * Math.random() * _radius;
        } while (x * x + y * y > _radius * _radius);
        return new double[]{_x + x, _y + y};
    }
}
