package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    int[] parents;
    int[] rank;

    public boolean validateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild) {
        parents = new int[n];
        rank = new int[n];
        int[] root = new int[n];
        for (int i = 0; i < n; i++) {
            parents[i] = i;
            root[i] = -1;
        }
        for (int i = 0; i < leftChild.length; i++) {
            if (leftChild[i] != -1) {
                if (root[leftChild[i]] != -1 && root[leftChild[i]] != i)
                    return false;
                root[leftChild[i]] = i;
                if (!union(i, leftChild[i]))
                    return false;
                n--;
            }
            if (rightChild[i] != -1) {
                if (root[rightChild[i]] != -1 && root[rightChild[i]] != i)
                    return false;
                root[rightChild[i]] = i;
                if (!union(i, rightChild[i]))
                    return false;
                n--;
            }
        }
        return n == 1;
    }

    public int find(int x) {
        if (parents[x] != x)
            parents[x] = find(parents[x]);
        return parents[x];
    }

    public boolean union(int x, int y) {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY)
            return false;
        if (rank[rootX] < rank[rootY])
            parents[rootX] = rootY;
        else {
            parents[rootY] = rootX;
            if (rank[rootX] == rank[rootY])
                rank[rootX]++;
        }
        return true;
    }
}
