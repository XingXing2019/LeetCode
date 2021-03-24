package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[] A = {16, 23, 15, 10, 19, 42, 13};
        int[] B = {13, 35, 20, 19, 25, 38, 42};
        advantageCount(A, B);
    }

    public static int[] advantageCount(int[] A, int[] B) {
        Map<Integer, Queue<Integer>> map = new HashMap<>();
        for (int i = 0; i < B.length; i++) {
            if (!map.containsKey(B[i]))
                map.put(B[i], new ArrayDeque<>());
            map.get(B[i]).offer(i);
        }
        Arrays.sort(A);
        Arrays.sort(B);
        int[] res = new int[A.length];
        Arrays.fill(res, -1);
        Queue<Integer> miss = new ArrayDeque<>();
        int indexA = 0, indexB = 0;
        while (indexA < A.length && indexB < B.length) {
            if (A[indexA] > B[indexB]) {
                int index = map.get(B[indexB]).poll();
                res[index] = A[indexA];
                indexB++;
            } else
                miss.offer(indexA);
            indexA++;
        }
        for (int i = 0; i < res.length; i++) {
            if (res[i] == -1)
                res[i] = A[miss.poll()];
        }
        return res;
    }
}
