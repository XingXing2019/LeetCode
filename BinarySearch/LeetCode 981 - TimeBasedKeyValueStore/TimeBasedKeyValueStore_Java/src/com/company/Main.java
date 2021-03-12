package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        TimeMap map = new TimeMap();
        map.set("foo", "bar", 1);
        System.out.println(map.get("foo", 1));
        System.out.println(map.get("foo", 3));
        map.set("foo", "bar2", 4);
        System.out.println(map.get("foo", 4));
        System.out.println(map.get("foo", 5));
    }
}

class Data {
    String val;
    int time;

    Data(String val, int time) {
        this.val = val;
        this.time = time;
    }
}

class TimeMap {
    Map<String, List<Data>> map;
    public TimeMap() {
        map = new HashMap<String, List<Data>>();
    }
    public void set(String key, String value, int timestamp) {
        if (!map.containsKey(key))
            map.put(key, new ArrayList<Data>());
        map.get(key).add(new Data(value, timestamp));
    }
    public String get(String key, int timestamp) {
        if (!map.containsKey(key))
            return "";
        return binarySearch(map.get(key), timestamp);
    }
    private String binarySearch(List<Data> list, int timestamp) {
        int low = 0, high = list.size() - 1;
        while (low < high) {
            int mid = (low + high) / 2;
            if (list.get(mid).time == timestamp)
                return list.get(mid).val;
            if (list.get(mid).time < timestamp) {
                if (list.get(mid + 1).time > timestamp)
                    return list.get(mid).val;
                low = mid + 1;
            } else
                high = mid - 1;
        }
        return list.get(low).time <= timestamp ? list.get(low).val : "";
    }
}