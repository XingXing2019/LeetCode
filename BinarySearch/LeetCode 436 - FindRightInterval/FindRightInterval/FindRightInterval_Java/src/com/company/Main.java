package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] findRightInterval(int[][] intervals) {
        Map<Integer, Integer> map = new HashMap<>();
        int[] starts = new int[intervals.length];
        int[] res = new int[intervals.length];
        for(int i = 0; i < intervals.length; i++){
            map.put(intervals[i][0], i);
            starts[i] = intervals[i][0];
        }
        Arrays.sort(starts);
        for(int i = 0; i < intervals.length; i++){
            int index = Arrays.binarySearch(starts, intervals[i][1]);
            if(index < 0) index = ~index;
            res[i] = index < starts.length ? map.get(starts[index]) : -1;
        }
        return res;
    }
}
