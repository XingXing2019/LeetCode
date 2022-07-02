with TotalSpending as (
	select user_id, product_id, sum(total_price) as total_spending
	from (
		select s.user_id, s.product_id, s.quantity * p.price as total_price
		from Sales s
		join Product p
		on s.product_id = p.product_id
	) as TotalPrice
	group by user_id, product_id
)

select user_id, product_id from TotalSpending 
where (user_id, total_spending) in (
	select user_id, max(total_spending) as max_spending
	from TotalSpending
	group by user_id
)