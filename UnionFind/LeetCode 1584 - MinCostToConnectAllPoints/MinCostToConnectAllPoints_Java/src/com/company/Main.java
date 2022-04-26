package com.company;

import java.util.ArrayList;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    int[] parents;
    int[] rank;
    public int minCostConnectPoints(int[][] points) {
        rank = new int[points.length];
        parents = new int[points.length];
        for (int i = 0; i < points.length; i++)
            parents[i] = i;
        var distances = new ArrayList<int[]>();
        for (int i = 0; i < points.length; i++) {
            for (int j = 0; j < points.length; j++) {
                if (i == j) continue;
                var dis = Math.abs(points[i][0] - points[j][0]) + Math.abs(points[i][1] - points[j][1]);
                distances.add(new int[] {i, j, dis});
            }
        }
        distances.sort((a, b) -> a[2] - b[2]);
        var res = 0;
        for (int[] dis : distances) {
            if (!union(dis[0], dis[1])) continue;
            res += dis[2];
        }
        return res;
    }

    public int find(int x) {
        return parents[x] == x ? parents[x] : find(parents[x]);
    }

    public boolean union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY) return false;
        if (rank[rootX] >= rank[rootY]) {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        } else {
            parents[rootX] = rootY;
        }
        return true;
    }
}
