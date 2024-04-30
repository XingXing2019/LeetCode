with Fridays as (
	select '2023-11-03' as friday, 1 as week_of_month
	union
	select '2023-11-10' as friday, 2 as week_of_month
	union
	select '2023-11-17' as friday, 3 as week_of_month
	union
	select '2023-11-24' as friday, 4 as week_of_month
) 

select week_of_month, membership, sum(amount_spend) as total_amount from (
	select week_of_month, 'Premium' as membership, friday, ifnull(amount_spend, 0) as amount_spend
	from Fridays
	left join (
		select purchase_date, amount_spend, membership
		from Purchases p
		join Users u on p.user_id = u.user_id
		where membership in ('Premium', 'VIP')
	) as t
	on friday = purchase_date
	and membership = 'Premium'
	
	union all
	
	select week_of_month, 'VIP' as membership, friday, ifnull(amount_spend, 0) as amount_spend
	from Fridays
	left join (
		select purchase_date, amount_spend, membership
		from Purchases p
		join Users u on p.user_id = u.user_id
		where membership in ('Premium', 'VIP')
	) as t
	on friday = purchase_date
	and membership = 'VIP'
) AS t
group by week_of_month, membership
order by week_of_month, membership