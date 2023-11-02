with ItemCount as (
	select u.seller_id, count(distinct i.item_id) as num_items
    from Orders o
    join Users u on o.seller_id = u.seller_id
    join Items i on i.item_id = o.item_id
    where u.favorite_brand <> i.item_brand
    group by u.seller_id
),

Ranks as (
	select *, rank() over(order by num_items desc) as ranks
	from ItemCount
)

select seller_id, num_items
from Ranks where ranks = 1