package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean canPlaceFlowers(int[] flowerbed, int n) {
        for (int i = 0; i < flowerbed.length; i++) {
            if (flowerbed[i] == 1) continue;
            int before = i - 1 < 0 ? 0 : flowerbed[i - 1];
            int after = i + 1 >= flowerbed.length ? 0 : flowerbed[i + 1];
            if (before == 0 && after == 0) {
                flowerbed[i] = 1;
                n--;
            }
        }
        return n <= 0;
    }
}
