with Fridays as (
	select 1 as week_of_month, '2023-11-03' as friday
    	union
    	select 2 as week_of_month, '2023-11-10' as friday
    	union
    	select 3 as week_of_month, '2023-11-17' as friday
   	union
    	select 4 as week_of_month, '2023-11-24' as friday
)

select week_of_month, friday as purchase_date, ifnull(total_amount, 0) as total_amount from Fridays
left join (
	select purchase_date, sum(amount_spend) as total_amount
    	from Purchases
   	where purchase_date in (select friday from Fridays)
    	group by purchase_date
) as t on friday = t.purchase_date
