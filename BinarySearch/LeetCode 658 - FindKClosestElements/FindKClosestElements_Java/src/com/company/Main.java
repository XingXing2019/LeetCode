package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] arr = {1};
        int k = 1, x = 1;
        System.out.println(findClosestElements(arr, k, x));
    }

    public static List<Integer> findClosestElements(int[] arr, int k, int x) {
        int index = Arrays.binarySearch(arr, x);
        PriorityQueue<Integer> heap = new PriorityQueue<>();
        if (index >= 0) heap.offer(x);
        int li = index < 0 ? ~index - 1 : index - 1;
        int hi = index < 0 ? ~index : index + 1;
        while (li >= 0 && hi < arr.length && heap.size() < k) {
            if (Math.abs(arr[li] - x) < Math.abs(arr[hi] - x))
                heap.offer(arr[li--]);
            else if (Math.abs(arr[li] - x) > Math.abs(arr[hi] - x))
                heap.offer(arr[hi++]);
            else
                heap.offer(arr[li] < arr[hi] ? arr[li--] : arr[hi++]);
        }
        while (heap.size() < k && li >= 0)
            heap.offer(arr[li--]);
        while (heap.size() < k && hi < arr.length)
            heap.offer(arr[hi++]);
        List<Integer> res = new ArrayList<>();
        while (!heap.isEmpty())
            res.add(heap.poll());
        return res;
    }
}
