select d.customer_id, name
from
(
	select a.customer_id, name, month(order_date) as month, sum(quantity*price) as total
	from orders a
	left outer join customers b
	on a.customer_id = b.customer_id
	left outer join product c
	on a.product_id = c.product_id
	where month(order_date) between 6 and 7 
	group by a.customer_id, month
	having total >= 100
) as d
group by d.customer_id, name
having COUNT(*) =2;