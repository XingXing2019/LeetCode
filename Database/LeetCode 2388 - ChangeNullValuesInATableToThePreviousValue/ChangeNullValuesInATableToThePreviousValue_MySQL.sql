with CoffeeShopRow as (
	select row_number() over(order by null) as row_num, id, drink
    from CoffeeShop
),

LastRow as (
	select *,
	sum(case when drink is null then 0 else 1 end) over(order by row_num) as last_row
	from CoffeeShopRow
)

select id, first_value(drink) over(partition by last_row) as drink
from LastRow