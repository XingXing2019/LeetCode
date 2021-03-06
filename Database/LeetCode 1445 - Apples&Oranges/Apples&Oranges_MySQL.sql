SELECT s1.sale_date, s2.sold_num - s1.sold_num diff
FROM sales s1 JOIN sales s2
ON s1.fruit != s2.fruit AND s1.sale_date = s2.sale_date
GROUP BY s1.sale_date
ORDER BY s1.sale_date;