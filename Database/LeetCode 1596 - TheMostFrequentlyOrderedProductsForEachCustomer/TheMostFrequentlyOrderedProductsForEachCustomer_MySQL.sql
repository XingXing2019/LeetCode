with cte as (select customer_id, product_id, count(product_id) count from orders group by customer_id, product_id)
select customer_id, p.product_id, p.product_name 
from (select *, rank() over(partition by customer_id order by count desc) as most from cte) as t
left join products p on t.product_id = p.product_id where most = 1

