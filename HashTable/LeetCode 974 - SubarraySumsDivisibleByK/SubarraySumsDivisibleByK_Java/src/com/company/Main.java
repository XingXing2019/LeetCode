package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	    int[] A = {4,5,0,-2,-3,1};
	    int K = 5;
	    System.out.print(subarraysDivByK(A, K));
    }
    public static int subarraysDivByK(int[] A, int K) {
        HashMap<Integer, Integer> map = new HashMap<>(){{put(0, 1);}};
        int prefix = 0, res = 0;
        for (int i = 0; i < A.length; i++) {
            prefix += A[i];
            int mod = prefix % K;
            if(mod < 0) mod += K;
            if(map.containsKey(mod))
                res += map.get(mod);
            else
                map.put(mod, 0);
            map.put(mod, map.get(mod) + 1);
        }
        return res;
    }
}
