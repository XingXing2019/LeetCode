package com.company;

import java.util.LinkedList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class MyLinkedList {
    List<Integer> list;

    public MyLinkedList() {
        list = new LinkedList<>();
    }

    public int get(int index) {
        return index < list.size() ? list.get(index) : -1;
    }

    public void addAtHead(int val) {
        list.add(0, val);
    }

    public void addAtTail(int val) {
        list.add(val);
    }

    public void addAtIndex(int index, int val) {
        if (index <= list.size())
            list.add(index, val);
    }

    public void deleteAtIndex(int index) {
        if (index < list.size())
            list.remove(index);
    }
}