package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int totalFruit(int[] tree) {
        int li = 0, hi = 0, res = 0;
        HashMap<Integer, Integer> map = new HashMap();
        while (hi < tree.length){
            if(!map.containsKey(tree[hi]))
                map.put(tree[hi], 1);
            else
                map.put(tree[hi], map.get(tree[hi]) + 1);
            while (map.size() > 2){
                map.put(tree[li], map.get(tree[li]) - 1);
                if(map.get(tree[li]) == 0)
                    map.remove(tree[li]);
                li++;
            }
            res = Math.max(res, hi - li + 1);
            hi++;
        }
        return res;
    }
}
