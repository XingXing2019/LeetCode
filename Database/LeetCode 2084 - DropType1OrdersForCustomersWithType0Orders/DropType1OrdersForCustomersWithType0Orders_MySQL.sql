with has_zero as (
	select distinct customer_id from orders where order_type = 0
)

select order_id, o.customer_id, order_type
from orders o
left join has_zero h
on o.customer_id = h.customer_id
where (h.customer_id is null)
or (h.customer_id is not null and o.order_type = 0)