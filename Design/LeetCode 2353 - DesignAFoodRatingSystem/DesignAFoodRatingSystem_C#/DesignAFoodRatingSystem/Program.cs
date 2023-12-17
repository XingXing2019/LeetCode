using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignAFoodRatingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class FoodRatings
    {
        class Food : IComparable
        {
            public string name;
            public int rating;

            public Food(string name, int rating)
            {
                this.name = name;
                this.rating = rating;
            }

            public int CompareTo(object obj)
            {
                var food = obj as Food;
                if (rating == food.rating)
                    return name.CompareTo(food.name) < 0 ? 1 : -1;
                return rating > food.rating ? 1 : -1;
            }
        }

        class Cuisine
        {
            public string name;
            public SortedSet<Food> foods;

            public Cuisine(string name)
            {
                this.name = name;
                foods = new SortedSet<Food>();
            }
        }

        private Dictionary<string, Food> foodDict;
        private Dictionary<string, Cuisine> cuisineDict;
        private Dictionary<string, string> foodCuisineDict;
        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            foodDict = new Dictionary<string, Food>();
            cuisineDict = new Dictionary<string, Cuisine>();
            foodCuisineDict = new Dictionary<string, string>();
            for (int i = 0; i < foods.Length; i++)
            {
                var food = new Food(foods[i], ratings[i]);
                var cuisine = cuisines[i];
                cuisineDict[cuisine] = cuisineDict.GetValueOrDefault(cuisine, new Cuisine(cuisine));
                foodDict[foods[i]] = food;
                cuisineDict[cuisine].foods.Add(food);
                foodCuisineDict[foods[i]] = cuisine;
            }
        }

        public void ChangeRating(string food, int newRating)
        {
            var cuisine = cuisineDict[foodCuisineDict[food]];
            var foodObj = foodDict[food];
            if (foodObj.rating == newRating) return;
            cuisine.foods.Remove(foodObj);
            foodObj.rating = newRating;
            cuisine.foods.Add(foodObj);
        }

        public string HighestRated(string cuisine)
        {
            var cuisneObj = cuisineDict[cuisine];
            return cuisneObj.foods.Max.name;
        }
    }
}
