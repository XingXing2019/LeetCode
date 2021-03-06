SELECT s1.sale_date, s1.sold_num - s2.sold_num AS diff FROM sales s1 
JOIN sales s2 ON s1.sale_date = s2.sale_date AND s1.fruit <> s2.fruit AND s1.fruit = 'apples'