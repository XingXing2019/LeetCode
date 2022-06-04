with OrderInYear as (
	select product_id, year(purchase_date) as year
	from Orders
	group by product_id, year(purchase_date)
	having count(distinct order_id) >= 3
)

select distinct o1.product_id
from OrderInYear o1 join OrderInYear o2
on o1.product_id = o2.product_id
and o1.year - o2.year = 1