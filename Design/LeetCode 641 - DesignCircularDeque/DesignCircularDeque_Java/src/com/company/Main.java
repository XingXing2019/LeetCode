package com.company;

public class Main {

    public static void main(String[] args) {
        var obj = new MyCircularDeque(4);
        System.out.println(obj.insertLast(1));
        System.out.println(obj.insertFront(2));
        System.out.println(obj.insertLast(3));
        System.out.println(obj.deleteLast());
        System.out.println(obj.deleteFront());
        System.out.println(obj.deleteFront());
        System.out.println(obj.getFront());
    }
}

class MyCircularDeque {
    class Node {
        int val;
        Node previous;
        Node next;

        public Node(int val, Node previous, Node next) {
            this.val = val;
            this.previous = previous;
            this.next = next;
        }
    }

    int _k;
    int _size;
    Node _front;
    Node _rear;

    public MyCircularDeque(int k) {
        _k = k;
    }

    public boolean insertFront(int value) {
        if (_size == _k) return false;
        if (_front == null && _rear == null) {
            _front = new Node(value, null, null);
            _rear = _front;
        } else {
            Node node = new Node(value, null, _front);
            _front.previous = node;
            _front = node;
        }
        _size++;
        return true;
    }

    public boolean insertLast(int value) {
        if (_size == _k) return false;
        if (_front == null && _rear == null) {
            _rear = new Node(value, null, null);
            _front = _rear;
        } else {
            Node node = new Node(value, _rear, null);
            _rear.next = node;
            _rear = node;
        }
        _size++;
        return true;
    }

    public boolean deleteFront() {
        if (_size == 0) return false;
        _size--;
        _front = _front.next;
        if (_front != null) _front.previous = null;
        if (_front == null) _rear = null;
        return true;
    }

    public boolean deleteLast() {
        if (_size == 0) return false;
        _size--;
        _rear = _rear.previous;
        if (_rear != null) _rear.next = null;
        if (_rear == null) _front = null;
        return true;
    }

    public int getFront() {
        return _front == null ? -1 : _front.val;
    }

    public int getRear() {
        return _rear == null ? -1 : _rear.val;
    }

    public boolean isEmpty() {
        return _size == 0;
    }

    public boolean isFull() {
        return _size == _k;
    }
}
