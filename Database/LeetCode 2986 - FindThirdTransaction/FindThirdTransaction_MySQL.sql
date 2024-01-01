with DateRank as (
	select *, rank() over(partition by user_id order by transaction_date) as date_rank
	from Transactions
)

select d3.user_id, d3.spend as third_transaction_spend, d3.transaction_date as third_transaction_date
from DateRank d1
join DateRank d2 on d1.user_id = d2.user_id and d1.date_rank + 1 = d2.date_rank
join DateRank d3 on d2.user_id = d3.user_id and d2.date_rank + 1 = d3.date_rank
where d1.spend < d3.spend 
and d2.spend < d3.spend 
and d3.date_rank = 3