with cte as (select *, rank() over(partition by customer_id order by order_date desc) as 'rank' from orders)
select c2.name as customer_name, c2.customer_id, c1.order_id, c1.order_date from cte c1 left join customers c2 on c1.customer_id = c2.customer_id where c1.rank < 4
order by c2.name, c2.customer_id, c1.order_date desc