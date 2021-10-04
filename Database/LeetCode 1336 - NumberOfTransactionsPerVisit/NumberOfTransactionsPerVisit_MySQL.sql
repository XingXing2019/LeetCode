with recursive trans_count as (
	select transactions, count(transactions) as visits_count from (
		select v.user_id, v.visit_date, count(transaction_date) as transactions
		from visits v
		left join transactions t
		on v.user_id = t.user_id and v.visit_date = t.transaction_date
		group by v.user_id, v.visit_date
	) as t group by transactions
),
max_count as (
	select max(transactions) as max_count from trans_count
),
visit_count as (
	select 0 as transactions_count
	union all
	select transactions_count + 1 as transactions_count
	from visit_count
	where transactions_count < (select * from max_count)
)

select transactions_count, ifnull(visits_count, 0) as visits_count
from visit_count v
left join trans_count t
on v.transactions_count = t.transactions