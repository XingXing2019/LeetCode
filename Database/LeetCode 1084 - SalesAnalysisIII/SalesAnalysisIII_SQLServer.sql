select p.product_id, p.product_name from product p left join
(select product_id, min(sale_date) firestDate, max(sale_date) as lastDate from sales group by product_id) as t 
on p.product_id = t.product_id
where t.firestDate >= '2019-01-01' and t.lastDate <= '2019-03-31';

select product_id, product_name from product where product_id not in 
(select distinct product_id from sales where sale_date not between '2019-01-01' and '2019-03-31');