package com.company;

import java.util.LinkedList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        var stream = new OrderedStream(5);
        System.out.println(stream.insert(3, "cccc"));
    }
}

class OrderedStream {
    String[] values;
    int index;

    public OrderedStream(int n) {
        values = new String[n];
    }

    public List<String> insert(int idKey, String value) {
        values[idKey - 1] = value;
        List<String> res = new LinkedList<>();
        while (index < values.length && values[index] != null)
            res.add(values[index++]);
        return res;
    }
}
