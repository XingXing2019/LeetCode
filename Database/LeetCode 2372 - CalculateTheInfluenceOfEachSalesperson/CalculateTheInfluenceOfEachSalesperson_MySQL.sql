select s.*, ifnull(TotalPrice.total, 0) as total
from Salesperson s
left join (
	select c.salesperson_id, sum(s.price) as total
	from Sales s
	join customer c on s.customer_id = c.customer_id
	group by c.salesperson_id
) as TotalPrice
on s.salesperson_id = TotalPrice.salesperson_id