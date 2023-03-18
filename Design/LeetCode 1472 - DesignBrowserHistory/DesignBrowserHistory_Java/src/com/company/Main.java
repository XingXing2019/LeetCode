package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class BrowserHistory {

    class ListNode {
        String url;
        ListNode pre;
        ListNode next;
        public ListNode (String url) {
            this.url = url;
        }
    }

    ListNode cur;
    public BrowserHistory(String homepage) {
        cur = new ListNode(homepage);
    }

    public void visit(String url) {
        var next = new ListNode(url);
        cur.next = next;
        next.pre = cur;
        cur = cur.next;
    }

    public String back(int steps) {
        while (cur.pre != null && steps != 0) {
            cur = cur.pre;
            steps--;
        }
        return cur.url;
    }

    public String forward(int steps) {
        while (cur.next != null && steps != 0) {
            cur = cur.next;
            steps--;
        }
        return cur.url;
    }
}