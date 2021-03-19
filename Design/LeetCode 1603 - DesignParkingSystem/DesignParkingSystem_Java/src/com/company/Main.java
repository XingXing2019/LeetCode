package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class ParkingSystem {
    int[] _carPark;
    public ParkingSystem(int big, int medium, int small) {
        _carPark = new int[]{big, medium, small};
    }

    public boolean addCar(int carType) {
        _carPark[carType - 1]--;
        return _carPark[carType - 1] > -1;
    }
}