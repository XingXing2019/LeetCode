with MostFrequent as (
	select customer_id, category as top_category, rank() over(partition by customer_id order by count desc, date desc) as category_rank
    from  (
		select t.customer_id, category, count(transaction_id) as count, max(transaction_date) as date
		from Transactions t
		join Products p on t.product_id = p.product_id 
		group by t.customer_id, category
    ) as t	
)

select t.customer_id, total_amount, transaction_count, unique_categories, avg_transaction_amount, top_category, loyalty_score
from MostFrequent m
join (
	select 
		t.customer_id, 
        sum(amount) as total_amount,
        count(transaction_id) as transaction_count, 
        count(distinct category) as unique_categories,
        round(sum(amount) / count(transaction_id), 2) as avg_transaction_amount,
        round(count(transaction_id) * 10 + sum(amount) / 100, 2) as loyalty_score
	from Transactions t
	join Products p on t.product_id = p.product_id 
	group by t.customer_id
) as t on t.customer_id = m.customer_id
where category_rank = 1
order by loyalty_score desc, t.customer_id