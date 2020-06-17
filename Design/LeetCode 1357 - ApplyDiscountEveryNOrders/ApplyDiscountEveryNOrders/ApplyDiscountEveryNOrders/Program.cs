using System;
using System.Collections.Generic;

namespace ApplyDiscountEveryNOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            var casher = new Cashier(3, 50, new[] {1, 2, 3, 4, 5, 6, 7}, new[] {100, 200, 300, 400, 300, 200, 100});
            casher.GetBill(new[] {1, 2}, new[] {1, 2});
            casher.GetBill(new[] {3, 7}, new[] {10, 10});
            casher.GetBill(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 1, 1, 1, 1, 1, 1 });
        }
    }
    public class Cashier
    {
        private Dictionary<int, int> _prices;
        private int _n;
        private double _discount;
        private int customers;
        public Cashier(int n, int discount, int[] products, int[] prices)
        {
            _n = n;
            _discount = discount;
            _prices = new Dictionary<int, int>();
            for (int i = 0; i < products.Length; i++)
                _prices[products[i]] = prices[i];
        }

        public double GetBill(int[] product, int[] amount)
        {
            customers++;
            double totalPrice = 0;
            for (int i = 0; i < product.Length; i++)
                totalPrice += _prices[product[i]] * amount[i];
            if (customers % _n == 0)
                totalPrice *= (1 - _discount / 100);
            return totalPrice;
        }
    }

}
