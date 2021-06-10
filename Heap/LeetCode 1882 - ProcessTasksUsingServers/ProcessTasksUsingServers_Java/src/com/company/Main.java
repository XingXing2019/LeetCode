package com.company;

import java.util.ArrayDeque;
import java.util.PriorityQueue;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        int[] servers = {5,1,4,3,2};
        int[] tasks = {2, 1, 2, 4, 5, 2, 1};
        System.out.println(assignTasks(servers, tasks));
    }

    public static int[] assignTasks(int[] servers, int[] tasks) {
        PriorityQueue<int[]> idle = new PriorityQueue<>((a, b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        PriorityQueue<int[]> busy = new PriorityQueue<>((a, b) -> a[2] - b[2]);
        for (int i = 0; i < servers.length; i++)
            idle.offer(new int[]{servers[i], i});
        int[] res = new int[tasks.length];
        int time = 0, index = 0;
        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(index++);
        while (!queue.isEmpty()){
            while (!idle.isEmpty() && !queue.isEmpty()){
                int[] server = idle.poll();
                int task = queue.poll();
                res[task] = server[1];
                busy.offer(new int[]{server[0], server[1], time + tasks[task]});
            }
            if (idle.isEmpty())
                time = busy.peek()[2];
            else time++;
            while (!busy.isEmpty() && busy.peek()[2] == time) {
                int[] server = busy.poll();
                idle.offer(new int[]{server[0], server[1]});
            }
            while (index < tasks.length && index <= time)
                queue.offer(index++);
        }
        return res;
    }
}
