with increment_transactions as (
	select customer_id, transaction_date, row_number() over(partition by customer_id order by transaction_date) as rn
	from (
		select t1.customer_id, t1.transaction_date
		from transactions t1 
		join transactions t2
		on t1.customer_id = t2.customer_id
		and t1.amount < t2.amount
		and datediff(t2.transaction_date, t1.transaction_date) = 1
	) as t
)

select customer_id, consecutive_start, date_add(consecutive_start, interval days day) as consecutive_end
from (
	select customer_id, base_date, min(transaction_date) as consecutive_start, count(*) as days
	from (
		select customer_id, transaction_date, date_add(transaction_date, interval -rn day) as base_date
		from increment_transactions
	) as t
	group by customer_id, base_date
	having count(*) >= 2
) as t
order by customer_id