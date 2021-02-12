select s.product_id, first_year, quantity, price from sales s right join 
(select product_id, min(year) first_year from sales group by product_id) t
on s.product_id = t.product_id and s.year = t.first_year