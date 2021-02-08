package com.company;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}


class PeekingIterator implements Iterator<Integer> {

    private Iterator<Integer> iter;
    private Integer peekedValue = null;
    public PeekingIterator(Iterator<Integer> iterator) {
        iter = iterator;
    }

    public Integer peek() {
        if (peekedValue == null) {
            peekedValue = iter.next();
        }
        return peekedValue;
    }

    @Override
    public Integer next() {
        if (peekedValue != null) {
            Integer toReturn = peekedValue;
            peekedValue = null;
            return toReturn;
        }
        return iter.next();
    }

    @Override
    public boolean hasNext() {
        return peekedValue != null || iter.hasNext();
    }
}
