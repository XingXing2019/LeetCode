with cte as (select customer_id, min(order_date) as first from delivery group by customer_id)
select round(count(*) / (select count(*) from cte) * 100, 2) as immediate_percentage 
from cte c inner join delivery d 
on c.customer_id = d.customer_id and c.first = d.order_date
where order_date = customer_pref_delivery_date 