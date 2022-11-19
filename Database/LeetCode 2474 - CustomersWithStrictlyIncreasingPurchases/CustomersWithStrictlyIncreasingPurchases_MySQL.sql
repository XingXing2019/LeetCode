with CustomerOrders as (
	select customer_id, year(order_date) as year, sum(price) as total_price
	from Orders
	group by customer_id, year(order_date)
),

CustomerLastOrder as (
	select customer_id, max(year) as last_year
    from CustomerOrders
    group by customer_id
),

InvalidCustomers as (
	select distinct c1.customer_id
	from CustomerOrders c1
	left join CustomerOrders c2
	on c1.customer_id = c2.customer_id and c1.year + 1 = c2.year
	join CustomerLastOrder c3
	on c1.customer_id = c3.customer_id and c1.year <> c3.last_year
	where c1.total_price >= ifnull(c2.total_price, 0)
)

select distinct customer_id 
from Orders
where customer_id not in (select * from InvalidCustomers)