package com.company;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[][] slot1 = {{216397070,363167701}, {98730764,158208909}, {441003187,466254040}, {558239978,678368334}, {683942980,717766451}};
        int[][] slot2 = {{50490609,222653186}, {512711631,670791418}, {730229023,802410205}, {812553104,891266775}, {230032010,399152578}};
        int duration = 456085;
        minAvailableDuration(slot1, slot2, duration);
    }
    public static List<Integer> minAvailableDuration(int[][] slots1, int[][] slots2, int duration) {
        Arrays.sort(slots1, (a, b) -> a[0] - b[0]);
        Arrays.sort(slots2, (a, b) -> a[0] - b[0]);
        int p1 = 0, p2 = 0;
        while (p1 < slots1.length && p2 < slots2.length){
            int start1 = slots1[p1][0], end1 = slots1[p1][1];
            int start2 = slots2[p2][0], end2 = slots2[p2][1];
            if(start2 <= start1 && start1 + duration <= Math.min(end1, end2))
                return new ArrayList<>(){{add(start1); add(start1 + duration);}};
            if(start1 <= start2 && start2 + duration <= Math.min(end1, end2))
                return new ArrayList<>(){{add(start2); add(start2 + duration);}};
            if (end1 > end2) p2++;
            else p1++;
        }
        return new ArrayList<>();
    }
}
