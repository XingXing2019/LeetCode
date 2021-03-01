with saleRank as (select *, rank() over(partition by seller_id order by order_date) as saleRank from orders),
sales as (select seller_id, saleRank, item_brand from saleRank s left join items i on s.item_id = i.item_id where saleRank = 2)

select user_id as seller_id, case when favorite_brand = item_brand then 'yes' else 'no' end as 2nd_item_fav_brand    
from users u left join sales s on u.user_id = s.seller_id