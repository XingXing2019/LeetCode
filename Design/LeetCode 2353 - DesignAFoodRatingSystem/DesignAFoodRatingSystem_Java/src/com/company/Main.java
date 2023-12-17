package com.company;

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class FoodRatings {
    class Food {
        int Rating;
        String Name;
        String Cuisine;

        public Food(int rating, String name, String cuisine) {
            Rating = rating;
            Name = name;
            Cuisine = cuisine;
        }
    }

    Map<String, PriorityQueue<Food>> map;
    Map<String, Food> foodDict;
    Map<String, String> cuisineDict;
    public FoodRatings(String[] foods, String[] cuisines, int[] ratings) {
        map = new HashMap<>();
        foodDict = new HashMap<>();
        cuisineDict = new HashMap<>();
        for (int i = 0; i < foods.length; i++) {
            var food = new Food(ratings[i], foods[i], cuisines[i]);
            if (!map.containsKey(food.Cuisine)) {
                var heap = new PriorityQueue<Food>((a, b) -> a.Rating == b.Rating ? a.Name.compareTo(b.Name) : b.Rating - a.Rating);
                map.put(food.Cuisine, heap);
            }
            map.get(food.Cuisine).offer(food);
            foodDict.put(food.Name, food);
            cuisineDict.put(food.Name, food.Cuisine);
        }
    }

    public void changeRating(String food, int newRating) {
        var f = foodDict.get(food);
        var foods = map.get(cuisineDict.get(food));
        foods.remove(f);
        f.Rating = newRating;
        foods.offer(f);
    }

    public String highestRated(String cuisine) {
        return map.get(cuisine).peek().Name;
    }
}