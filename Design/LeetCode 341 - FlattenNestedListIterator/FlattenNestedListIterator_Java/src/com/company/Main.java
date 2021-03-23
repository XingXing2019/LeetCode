package com.company;

import java.util.Iterator;
import java.util.List;
import java.util.Stack;

interface NestedInteger {

    public boolean isInteger();

    public Integer getInteger();

    public List<NestedInteger> getList();
}

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}
class NestedIterator implements Iterator<Integer> {
    Stack<Integer> nums;    
    public NestedIterator(List<NestedInteger> nestedList) {
        nums = new Stack<>();
        dfs(nestedList);
    }

    private void dfs(List<NestedInteger> nestedList) {
        for (int i = nestedList.size() - 1; i >= 0; i--) {
            if(nestedList.get(i).isInteger())
                nums.push(nestedList.get(i).getInteger());
            else
                dfs(nestedList.get(i).getList());
        }
    }

    @Override
    public Integer next() {
        return nums.pop();
    }

    @Override
    public boolean hasNext() {
        return !nums.isEmpty();
    }
}
