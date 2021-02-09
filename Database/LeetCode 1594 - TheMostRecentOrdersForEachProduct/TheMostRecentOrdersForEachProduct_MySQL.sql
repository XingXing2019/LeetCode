with cte as (select *, rank() over(partition by product_id order by order_date desc) as dateRank from orders)
select p.product_name, p.product_id, c.order_id, c.order_date 
from cte c left join products p on c.product_id = p.product_id 
where dateRank = 1
order by p.product_name, product_id, order_id
