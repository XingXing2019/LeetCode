package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean canFormArray(int[] arr, int[][] pieces) {
        HashMap<Integer, int[]> map = new HashMap<>();
        for (int[] piece : pieces)
            map.put(piece[0], piece);
        int index = 0;
        while(index < arr.length){
            if(!map.containsKey(arr[index])) return false;
            int[] temp = map.get(arr[index]);
            for (int i = 0; i < temp.length; i++)
                if(arr[index++] != temp[i]) return false;
        }
        return true;
    }
}
