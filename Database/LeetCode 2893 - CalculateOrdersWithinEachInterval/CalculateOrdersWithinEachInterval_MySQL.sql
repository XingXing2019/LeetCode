select order_groups + 1 as interval_no, sum(order_count) as total_orders
from (
	select order_count, floor((minute - 1) / 6) as order_groups from Orders
) as OrderGroups
group by order_groups