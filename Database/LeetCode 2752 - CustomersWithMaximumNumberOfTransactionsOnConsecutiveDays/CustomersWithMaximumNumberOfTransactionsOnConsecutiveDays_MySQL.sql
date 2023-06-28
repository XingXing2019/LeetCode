with StartDate as (
	select customer_id, adddate(transaction_date, -days) as start_date from (
		select customer_id, transaction_date, row_number() over(partition by customer_id order by transaction_date) as days from Transactions
	) as t
),

TransCount as (
	select customer_id, start_date, count(*) as counts
	from StartDate
	group by customer_id, start_date
)

select customer_id from TransCount
where counts = (select max(counts) from TransCount)
order by customer_id